"use strict";
/**
 * Copyright (c) Microsoft Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
Object.defineProperty(exports, "__esModule", { value: true });
exports.snapshotScript = exports.frameSnapshotStreamer = exports.kSnapshotBinding = exports.kSnapshotStreamer = void 0;
exports.kSnapshotStreamer = '__playwright_snapshot_streamer_';
exports.kSnapshotBinding = '__playwright_snapshot_binding_';
function frameSnapshotStreamer() {
    // Communication with Playwright.
    const kSnapshotStreamer = '__playwright_snapshot_streamer_';
    const kSnapshotBinding = '__playwright_snapshot_binding_';
    // Attributes present in the snapshot.
    const kShadowAttribute = '__playwright_shadow_root_';
    const kScrollTopAttribute = '__playwright_scroll_top_';
    const kScrollLeftAttribute = '__playwright_scroll_left_';
    // Symbols for our own info on Nodes/StyleSheets.
    const kSnapshotFrameId = Symbol('__playwright_snapshot_frameid_');
    const kCachedData = Symbol('__playwright_snapshot_cache_');
    function ensureCachedData(obj) {
        if (!obj[kCachedData])
            obj[kCachedData] = {};
        return obj[kCachedData];
    }
    function removeHash(url) {
        try {
            const u = new URL(url);
            u.hash = '';
            return u.toString();
        }
        catch (e) {
            return url;
        }
    }
    class Streamer {
        constructor() {
            this._removeNoScript = true;
            this._lastSnapshotNumber = 0;
            this._staleStyleSheets = new Set();
            this._allStyleSheetsWithUrlOverride = new Set();
            this._readingStyleSheet = false; // To avoid invalidating due to our own reads.
            this._interceptNativeMethod(window.CSSStyleSheet.prototype, 'insertRule', (sheet) => this._invalidateStyleSheet(sheet));
            this._interceptNativeMethod(window.CSSStyleSheet.prototype, 'deleteRule', (sheet) => this._invalidateStyleSheet(sheet));
            this._interceptNativeMethod(window.CSSStyleSheet.prototype, 'addRule', (sheet) => this._invalidateStyleSheet(sheet));
            this._interceptNativeMethod(window.CSSStyleSheet.prototype, 'removeRule', (sheet) => this._invalidateStyleSheet(sheet));
            this._interceptNativeGetter(window.CSSStyleSheet.prototype, 'rules', (sheet) => this._invalidateStyleSheet(sheet));
            this._interceptNativeGetter(window.CSSStyleSheet.prototype, 'cssRules', (sheet) => this._invalidateStyleSheet(sheet));
            this._fakeBase = document.createElement('base');
            this._observer = new MutationObserver(list => this._handleMutations(list));
            const observerConfig = { attributes: true, subtree: true };
            this._observer.observe(document, observerConfig);
            this._streamSnapshot();
        }
        _interceptNativeMethod(obj, method, cb) {
            const native = obj[method];
            if (!native)
                return;
            obj[method] = function (...args) {
                const result = native.call(this, ...args);
                cb(this, result);
                return result;
            };
        }
        _interceptNativeGetter(obj, prop, cb) {
            const descriptor = Object.getOwnPropertyDescriptor(obj, prop);
            Object.defineProperty(obj, prop, {
                ...descriptor,
                get: function () {
                    const result = descriptor.get.call(this);
                    cb(this, result);
                    return result;
                },
            });
        }
        _handleMutations(list) {
            for (const mutation of list)
                ensureCachedData(mutation.target).attributesCached = undefined;
        }
        _invalidateStyleSheet(sheet) {
            if (this._readingStyleSheet)
                return;
            this._staleStyleSheets.add(sheet);
            if (sheet.href !== null)
                this._allStyleSheetsWithUrlOverride.add(sheet);
        }
        _updateStyleElementStyleSheetTextIfNeeded(sheet) {
            const data = ensureCachedData(sheet);
            if (this._staleStyleSheets.has(sheet)) {
                this._staleStyleSheets.delete(sheet);
                try {
                    data.cssText = this._getSheetText(sheet);
                }
                catch (e) {
                    // Sometimes we cannot access cross-origin stylesheets.
                }
            }
            return data.cssText;
        }
        // Returns either content, ref, or no override.
        _updateLinkStyleSheetTextIfNeeded(sheet, snapshotNumber) {
            const data = ensureCachedData(sheet);
            if (this._staleStyleSheets.has(sheet)) {
                this._staleStyleSheets.delete(sheet);
                try {
                    data.cssText = this._getSheetText(sheet);
                    data.cssRef = snapshotNumber;
                    return data.cssText;
                }
                catch (e) {
                    // Sometimes we cannot access cross-origin stylesheets.
                }
            }
            return data.cssRef === undefined ? undefined : snapshotNumber - data.cssRef;
        }
        markIframe(iframeElement, frameId) {
            iframeElement[kSnapshotFrameId] = frameId;
        }
        forceSnapshot(snapshotId) {
            this._streamSnapshot(snapshotId);
        }
        _streamSnapshot(snapshotId) {
            if (this._timer) {
                clearTimeout(this._timer);
                this._timer = undefined;
            }
            try {
                const snapshot = this._captureSnapshot(snapshotId);
                window[kSnapshotBinding](snapshot).catch((e) => { });
            }
            catch (e) {
            }
            this._timer = setTimeout(() => this._streamSnapshot(), 100);
        }
        _sanitizeUrl(url) {
            if (url.startsWith('javascript:'))
                return '';
            return url;
        }
        _sanitizeSrcSet(srcset) {
            return srcset.split(',').map(src => {
                src = src.trim();
                const spaceIndex = src.lastIndexOf(' ');
                if (spaceIndex === -1)
                    return this._sanitizeUrl(src);
                return this._sanitizeUrl(src.substring(0, spaceIndex).trim()) + src.substring(spaceIndex);
            }).join(',');
        }
        _resolveUrl(base, url) {
            if (url === '')
                return '';
            try {
                return new URL(url, base).href;
            }
            catch (e) {
                return url;
            }
        }
        _getSheetBase(sheet) {
            let rootSheet = sheet;
            while (rootSheet.parentStyleSheet)
                rootSheet = rootSheet.parentStyleSheet;
            if (rootSheet.ownerNode)
                return rootSheet.ownerNode.baseURI;
            return document.baseURI;
        }
        _getSheetText(sheet) {
            this._readingStyleSheet = true;
            try {
                const rules = [];
                for (const rule of sheet.cssRules)
                    rules.push(rule.cssText);
                return rules.join('\n');
            }
            finally {
                this._readingStyleSheet = false;
            }
        }
        _captureSnapshot(snapshotId) {
            const snapshotNumber = ++this._lastSnapshotNumber;
            let nodeCounter = 0;
            let shadowDomNesting = 0;
            // Ensure we are up to date.
            this._handleMutations(this._observer.takeRecords());
            const visitNode = (node) => {
                const nodeType = node.nodeType;
                const nodeName = nodeType === Node.DOCUMENT_FRAGMENT_NODE ? 'template' : node.nodeName;
                if (nodeType !== Node.ELEMENT_NODE &&
                    nodeType !== Node.DOCUMENT_FRAGMENT_NODE &&
                    nodeType !== Node.TEXT_NODE)
                    return;
                if (nodeName === 'SCRIPT')
                    return;
                if (this._removeNoScript && nodeName === 'NOSCRIPT')
                    return;
                const data = ensureCachedData(node);
                const values = [];
                let equals = !!data.cached;
                let extraNodes = 0;
                const expectValue = (value) => {
                    equals = equals && data.cached[values.length] === value;
                    values.push(value);
                };
                const checkAndReturn = (n) => {
                    data.attributesCached = true;
                    if (equals)
                        return { equals: true, n: [[snapshotNumber - data.ref[0], data.ref[1]]] };
                    nodeCounter += extraNodes;
                    data.ref = [snapshotNumber, nodeCounter++];
                    data.cached = values;
                    return { equals: false, n };
                };
                if (nodeType === Node.TEXT_NODE) {
                    const value = node.nodeValue || '';
                    expectValue(value);
                    return checkAndReturn(value);
                }
                if (nodeName === 'STYLE') {
                    const sheet = node.sheet;
                    let cssText;
                    if (sheet)
                        cssText = this._updateStyleElementStyleSheetTextIfNeeded(sheet);
                    cssText = cssText || node.textContent || '';
                    expectValue(cssText);
                    // Compensate for the extra 'cssText' text node.
                    extraNodes++;
                    return checkAndReturn(['style', {}, cssText]);
                }
                const attrs = {};
                const result = [nodeName, attrs];
                const visitChild = (child) => {
                    const snapshotted = visitNode(child);
                    if (snapshotted) {
                        result.push(snapshotted.n);
                        expectValue(child);
                        equals = equals && snapshotted.equals;
                    }
                };
                if (nodeType === Node.DOCUMENT_FRAGMENT_NODE)
                    attrs[kShadowAttribute] = 'open';
                if (nodeType === Node.ELEMENT_NODE) {
                    const element = node;
                    // if (node === target)
                    //   attrs[' __playwright_target__] = '';
                    if (nodeName === 'INPUT') {
                        const value = element.value;
                        expectValue('value');
                        expectValue(value);
                        attrs['value'] = value;
                        if (element.checked) {
                            expectValue('checked');
                            attrs['checked'] = '';
                        }
                    }
                    if (element === document.scrollingElement) {
                        // TODO: restoring scroll positions of all elements
                        // is somewhat expensive. Figure this out.
                        if (element.scrollTop) {
                            expectValue(kScrollTopAttribute);
                            expectValue(element.scrollTop);
                            attrs[kScrollTopAttribute] = '' + element.scrollTop;
                        }
                        if (element.scrollLeft) {
                            expectValue(kScrollLeftAttribute);
                            expectValue(element.scrollLeft);
                            attrs[kScrollLeftAttribute] = '' + element.scrollLeft;
                        }
                    }
                    if (element.shadowRoot) {
                        ++shadowDomNesting;
                        visitChild(element.shadowRoot);
                        --shadowDomNesting;
                    }
                }
                if (nodeName === 'TEXTAREA') {
                    const value = node.value;
                    expectValue(value);
                    extraNodes++; // Compensate for the extra text node.
                    result.push(value);
                }
                else {
                    if (nodeName === 'HEAD') {
                        // Insert fake <base> first, to ensure all <link> elements use the proper base uri.
                        this._fakeBase.setAttribute('href', document.baseURI);
                        visitChild(this._fakeBase);
                    }
                    for (let child = node.firstChild; child; child = child.nextSibling)
                        visitChild(child);
                }
                // We can skip attributes comparison because nothing else has changed,
                // and mutation observer didn't tell us about the attributes.
                if (equals && data.attributesCached && !shadowDomNesting)
                    return checkAndReturn(result);
                if (nodeType === Node.ELEMENT_NODE) {
                    const element = node;
                    for (let i = 0; i < element.attributes.length; i++) {
                        const name = element.attributes[i].name;
                        if (name === 'value' && (nodeName === 'INPUT' || nodeName === 'TEXTAREA'))
                            continue;
                        if (nodeName === 'LINK' && name === 'integrity')
                            continue;
                        let value = element.attributes[i].value;
                        if (name === 'src' && (nodeName === 'IFRAME' || nodeName === 'FRAME')) {
                            // TODO: handle srcdoc?
                            const frameId = element[kSnapshotFrameId];
                            value = frameId || 'data:text/html,<body>Snapshot is not available</body>';
                        }
                        else if (name === 'src' && (nodeName === 'IMG')) {
                            value = this._sanitizeUrl(value);
                        }
                        else if (name === 'srcset' && (nodeName === 'IMG')) {
                            value = this._sanitizeSrcSet(value);
                        }
                        else if (name === 'srcset' && (nodeName === 'SOURCE')) {
                            value = this._sanitizeSrcSet(value);
                        }
                        else if (name === 'href' && (nodeName === 'LINK')) {
                            value = this._sanitizeUrl(value);
                        }
                        else if (name.startsWith('on')) {
                            value = '';
                        }
                        expectValue(name);
                        expectValue(value);
                        attrs[name] = value;
                    }
                }
                if (result.length === 2 && !Object.keys(attrs).length)
                    result.pop(); // Remove empty attrs when there are no children.
                return checkAndReturn(result);
            };
            let html;
            if (document.documentElement)
                html = visitNode(document.documentElement).n;
            else
                html = ['html'];
            const result = {
                html,
                doctype: document.doctype ? document.doctype.name : undefined,
                resourceOverrides: [],
                viewport: {
                    width: Math.max(document.body ? document.body.offsetWidth : 0, document.documentElement ? document.documentElement.offsetWidth : 0),
                    height: Math.max(document.body ? document.body.offsetHeight : 0, document.documentElement ? document.documentElement.offsetHeight : 0),
                },
                url: location.href,
                snapshotId,
            };
            for (const sheet of this._allStyleSheetsWithUrlOverride) {
                const content = this._updateLinkStyleSheetTextIfNeeded(sheet, snapshotNumber);
                if (content === undefined) {
                    // Unable to capture stylsheet contents.
                    continue;
                }
                const base = this._getSheetBase(sheet);
                const url = removeHash(this._resolveUrl(base, sheet.href));
                result.resourceOverrides.push({ url, content });
            }
            return result;
        }
    }
    window[kSnapshotStreamer] = new Streamer();
}
exports.frameSnapshotStreamer = frameSnapshotStreamer;
function snapshotScript() {
    function applyPlaywrightAttributes(shadowAttribute, scrollTopAttribute, scrollLeftAttribute) {
        const scrollTops = [];
        const scrollLefts = [];
        const visit = (root) => {
            // Collect all scrolled elements for later use.
            for (const e of root.querySelectorAll(`[${scrollTopAttribute}]`))
                scrollTops.push(e);
            for (const e of root.querySelectorAll(`[${scrollLeftAttribute}]`))
                scrollLefts.push(e);
            for (const iframe of root.querySelectorAll('iframe')) {
                const src = iframe.getAttribute('src') || '';
                if (src.startsWith('data:text/html'))
                    continue;
                // Rewrite iframes to use snapshot url (relative to window.location)
                // instead of begin relative to the <base> tag.
                const index = location.pathname.lastIndexOf('/');
                if (index === -1)
                    continue;
                const pathname = location.pathname.substring(0, index + 1) + src;
                const href = location.href.substring(0, location.href.indexOf(location.pathname)) + pathname;
                iframe.setAttribute('src', href);
            }
            for (const element of root.querySelectorAll(`template[${shadowAttribute}]`)) {
                const template = element;
                const shadowRoot = template.parentElement.attachShadow({ mode: 'open' });
                shadowRoot.appendChild(template.content);
                template.remove();
                visit(shadowRoot);
            }
        };
        visit(document);
        const onLoad = () => {
            window.removeEventListener('load', onLoad);
            for (const element of scrollTops) {
                element.scrollTop = +element.getAttribute(scrollTopAttribute);
                element.removeAttribute(scrollTopAttribute);
            }
            for (const element of scrollLefts) {
                element.scrollLeft = +element.getAttribute(scrollLeftAttribute);
                element.removeAttribute(scrollLeftAttribute);
            }
        };
        window.addEventListener('load', onLoad);
    }
    const kShadowAttribute = '__playwright_shadow_root_';
    const kScrollTopAttribute = '__playwright_scroll_top_';
    const kScrollLeftAttribute = '__playwright_scroll_left_';
    return `\n(${applyPlaywrightAttributes.toString()})('${kShadowAttribute}', '${kScrollTopAttribute}', '${kScrollLeftAttribute}')`;
}
exports.snapshotScript = snapshotScript;
//# sourceMappingURL=snapshotterInjected.js.map
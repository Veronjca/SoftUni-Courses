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
exports.Snapshotter = void 0;
const browserContext_1 = require("../server/browserContext");
const page_1 = require("../server/page");
const helper_1 = require("../server/helper");
const debugLogger_1 = require("../utils/debugLogger");
const snapshotterInjected_1 = require("./snapshotterInjected");
const utils_1 = require("../utils/utils");
class Snapshotter {
    constructor(context, delegate) {
        this._context = context;
        this._delegate = delegate;
        this._eventListeners = [
            helper_1.helper.addEventListener(this._context, browserContext_1.BrowserContext.Events.Page, this._onPage.bind(this)),
        ];
        this._context.exposeBinding(snapshotterInjected_1.kSnapshotBinding, false, (source, data) => {
            const snapshot = {
                doctype: data.doctype,
                html: data.html,
                viewport: data.viewport,
                resourceOverrides: [],
            };
            for (const { url, content } of data.resourceOverrides) {
                if (typeof content === 'string') {
                    const buffer = Buffer.from(content);
                    const sha1 = utils_1.calculateSha1(buffer);
                    this._delegate.onBlob({ sha1, buffer });
                    snapshot.resourceOverrides.push({ url, sha1 });
                }
                else {
                    snapshot.resourceOverrides.push({ url, ref: content });
                }
            }
            this._delegate.onFrameSnapshot(source.frame, data.url, snapshot, data.snapshotId);
        });
        this._context._doAddInitScript('(' + snapshotterInjected_1.frameSnapshotStreamer.toString() + ')()');
    }
    dispose() {
        helper_1.helper.removeEventListeners(this._eventListeners);
    }
    async forceSnapshot(page, snapshotId) {
        await Promise.all([
            page.frames().forEach(async (frame) => {
                try {
                    const context = await frame._mainContext();
                    await context.evaluateInternal(({ kSnapshotStreamer, snapshotId }) => {
                        // Do not block action execution on the actual snapshot.
                        Promise.resolve().then(() => window[kSnapshotStreamer].forceSnapshot(snapshotId));
                        return undefined;
                    }, { kSnapshotStreamer: snapshotterInjected_1.kSnapshotStreamer, snapshotId });
                }
                catch (e) {
                }
            })
        ]);
    }
    _onPage(page) {
        this._eventListeners.push(helper_1.helper.addEventListener(page, page_1.Page.Events.Response, (response) => {
            this._saveResource(page, response).catch(e => debugLogger_1.debugLogger.log('error', e));
        }));
        this._eventListeners.push(helper_1.helper.addEventListener(page, page_1.Page.Events.FrameAttached, async (frame) => {
            try {
                const frameElement = await frame.frameElement();
                const parent = frame.parentFrame();
                if (!parent)
                    return;
                const context = await parent._mainContext();
                await context.evaluateInternal(({ kSnapshotStreamer, frameElement, frameId }) => {
                    window[kSnapshotStreamer].markIframe(frameElement, frameId);
                }, { kSnapshotStreamer: snapshotterInjected_1.kSnapshotStreamer, frameElement, frameId: frame._id });
                frameElement.dispose();
            }
            catch (e) {
                // Ignore
            }
        }));
    }
    async _saveResource(page, response) {
        const isRedirect = response.status() >= 300 && response.status() <= 399;
        if (isRedirect)
            return;
        // Shortcut all redirects - we cannot intercept them properly.
        let original = response.request();
        while (original.redirectedFrom())
            original = original.redirectedFrom();
        const url = original.url();
        let contentType = '';
        for (const { name, value } of response.headers()) {
            if (name.toLowerCase() === 'content-type')
                contentType = value;
        }
        const method = original.method();
        const status = response.status();
        const requestBody = original.postDataBuffer();
        const requestSha1 = requestBody ? utils_1.calculateSha1(requestBody) : 'none';
        const requestHeaders = original.headers();
        const body = await response.body().catch(e => debugLogger_1.debugLogger.log('error', e));
        const responseSha1 = body ? utils_1.calculateSha1(body) : 'none';
        const resource = {
            pageId: this._delegate.pageId(page),
            frameId: response.frame()._id,
            url,
            contentType,
            responseHeaders: response.headers(),
            requestHeaders,
            method,
            status,
            requestSha1,
            responseSha1,
        };
        this._delegate.onResource(resource);
        if (requestBody)
            this._delegate.onBlob({ sha1: requestSha1, buffer: requestBody });
        if (body)
            this._delegate.onBlob({ sha1: responseSha1, buffer: body });
    }
}
exports.Snapshotter = Snapshotter;
//# sourceMappingURL=snapshotter.js.map
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
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    Object.defineProperty(o, k2, { enumerable: true, get: function() { return m[k]; } });
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || function (mod) {
    if (mod && mod.__esModule) return mod;
    var result = {};
    if (mod != null) for (var k in mod) if (k !== "default" && Object.prototype.hasOwnProperty.call(mod, k)) __createBinding(result, mod, k);
    __setModuleDefault(result, mod);
    return result;
};
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Tracer = void 0;
const browserContext_1 = require("../server/browserContext");
const path_1 = __importDefault(require("path"));
const util = __importStar(require("util"));
const fs_1 = __importDefault(require("fs"));
const utils_1 = require("../utils/utils");
const page_1 = require("../server/page");
const snapshotter_1 = require("./snapshotter");
const helper_1 = require("../server/helper");
const frames_1 = require("../server/frames");
const snapshotterInjected_1 = require("./snapshotterInjected");
const fsWriteFileAsync = util.promisify(fs_1.default.writeFile.bind(fs_1.default));
const fsAppendFileAsync = util.promisify(fs_1.default.appendFile.bind(fs_1.default));
const fsAccessAsync = util.promisify(fs_1.default.access.bind(fs_1.default));
const envTrace = utils_1.getFromENV('PW_TRACE_DIR');
class Tracer {
    constructor() {
        this._contextTracers = new Map();
    }
    async onContextCreated(context) {
        const traceDir = envTrace || context._options._traceDir;
        if (!traceDir)
            return;
        const traceStorageDir = path_1.default.join(traceDir, 'resources');
        const tracePath = path_1.default.join(traceDir, utils_1.createGuid() + '.trace');
        const contextTracer = new ContextTracer(context, traceStorageDir, tracePath);
        this._contextTracers.set(context, contextTracer);
    }
    async onContextDidDestroy(context) {
        const contextTracer = this._contextTracers.get(context);
        if (contextTracer) {
            await contextTracer.dispose().catch(e => { });
            this._contextTracers.delete(context);
        }
    }
    async onBeforeInputAction(sdkObject, metadata) {
        var _a;
        (_a = this._contextTracers.get(sdkObject.attribution.context)) === null || _a === void 0 ? void 0 : _a.onActionCheckpoint('before', sdkObject, metadata);
    }
    async onAfterInputAction(sdkObject, metadata) {
        var _a;
        (_a = this._contextTracers.get(sdkObject.attribution.context)) === null || _a === void 0 ? void 0 : _a.onActionCheckpoint('after', sdkObject, metadata);
    }
    async onAfterCall(sdkObject, metadata) {
        var _a;
        (_a = this._contextTracers.get(sdkObject.attribution.context)) === null || _a === void 0 ? void 0 : _a.onAfterCall(sdkObject, metadata);
    }
}
exports.Tracer = Tracer;
const pageIdSymbol = Symbol('pageId');
const snapshotsSymbol = Symbol('snapshots');
// This is an official way to pass snapshots between onBefore/AfterInputAction and onAfterCall.
function snapshotsForMetadata(metadata) {
    if (!metadata[snapshotsSymbol])
        metadata[snapshotsSymbol] = [];
    return metadata[snapshotsSymbol];
}
class ContextTracer {
    constructor(context, traceStorageDir, traceFile) {
        this._disposed = false;
        this._context = context;
        this._contextId = 'context@' + utils_1.createGuid();
        this._traceFile = traceFile;
        this._traceStoragePromise = utils_1.mkdirIfNeeded(path_1.default.join(traceStorageDir, 'sha1')).then(() => traceStorageDir);
        this._appendEventChain = utils_1.mkdirIfNeeded(traceFile).then(() => traceFile);
        this._writeArtifactChain = Promise.resolve();
        const event = {
            timestamp: utils_1.monotonicTime(),
            type: 'context-created',
            browserName: context._browser.options.name,
            contextId: this._contextId,
            isMobile: !!context._options.isMobile,
            deviceScaleFactor: context._options.deviceScaleFactor || 1,
            viewportSize: context._options.viewport || undefined,
            debugName: context._options._debugName,
            snapshotScript: snapshotterInjected_1.snapshotScript(),
        };
        this._appendTraceEvent(event);
        this._snapshotter = new snapshotter_1.Snapshotter(context, this);
        this._eventListeners = [
            helper_1.helper.addEventListener(context, browserContext_1.BrowserContext.Events.Page, this._onPage.bind(this)),
        ];
    }
    onBlob(blob) {
        this._writeArtifact(blob.sha1, blob.buffer);
    }
    onResource(resource) {
        const event = {
            timestamp: utils_1.monotonicTime(),
            type: 'resource',
            contextId: this._contextId,
            pageId: resource.pageId,
            frameId: resource.frameId,
            resourceId: 'resource@' + utils_1.createGuid(),
            url: resource.url,
            contentType: resource.contentType,
            responseHeaders: resource.responseHeaders,
            requestHeaders: resource.requestHeaders,
            method: resource.method,
            status: resource.status,
            requestSha1: resource.requestSha1,
            responseSha1: resource.responseSha1,
        };
        this._appendTraceEvent(event);
    }
    onFrameSnapshot(frame, frameUrl, snapshot, snapshotId) {
        const event = {
            timestamp: utils_1.monotonicTime(),
            type: 'snapshot',
            contextId: this._contextId,
            pageId: this.pageId(frame._page),
            frameId: frame._page.mainFrame() === frame ? '' : frame._id,
            snapshot: snapshot,
            frameUrl,
            snapshotId,
        };
        this._appendTraceEvent(event);
    }
    pageId(page) {
        return page[pageIdSymbol];
    }
    async onActionCheckpoint(name, sdkObject, metadata) {
        if (!sdkObject.attribution.page)
            return;
        const snapshotId = utils_1.createGuid();
        snapshotsForMetadata(metadata).push({ name, snapshotId });
        await this._snapshotter.forceSnapshot(sdkObject.attribution.page, snapshotId);
    }
    async onAfterCall(sdkObject, metadata) {
        if (!sdkObject.attribution.page)
            return;
        const event = {
            timestamp: utils_1.monotonicTime(),
            type: 'action',
            contextId: this._contextId,
            pageId: this.pageId(sdkObject.attribution.page),
            objectType: metadata.type,
            method: metadata.method,
            // FIXME: filter out evaluation snippets, binary
            params: metadata.params,
            stack: metadata.stack,
            startTime: metadata.startTime,
            endTime: metadata.endTime,
            logs: metadata.log.slice(),
            error: metadata.error,
            snapshots: snapshotsForMetadata(metadata),
        };
        this._appendTraceEvent(event);
    }
    _onPage(page) {
        const pageId = 'page@' + utils_1.createGuid();
        page[pageIdSymbol] = pageId;
        const event = {
            timestamp: utils_1.monotonicTime(),
            type: 'page-created',
            contextId: this._contextId,
            pageId,
        };
        this._appendTraceEvent(event);
        page.on(page_1.Page.Events.VideoStarted, (video) => {
            if (this._disposed)
                return;
            const event = {
                timestamp: utils_1.monotonicTime(),
                type: 'page-video',
                contextId: this._contextId,
                pageId,
                fileName: path_1.default.relative(path_1.default.dirname(this._traceFile), video._path),
            };
            this._appendTraceEvent(event);
        });
        page.on(page_1.Page.Events.Dialog, (dialog) => {
            if (this._disposed)
                return;
            const event = {
                timestamp: utils_1.monotonicTime(),
                type: 'dialog-opened',
                contextId: this._contextId,
                pageId,
                dialogType: dialog.type(),
                message: dialog.message(),
            };
            this._appendTraceEvent(event);
        });
        page.on(page_1.Page.Events.InternalDialogClosed, (dialog) => {
            if (this._disposed)
                return;
            const event = {
                timestamp: utils_1.monotonicTime(),
                type: 'dialog-closed',
                contextId: this._contextId,
                pageId,
                dialogType: dialog.type(),
            };
            this._appendTraceEvent(event);
        });
        page.mainFrame().on(frames_1.Frame.Events.Navigation, (navigationEvent) => {
            if (this._disposed || page.mainFrame().url() === 'about:blank')
                return;
            const event = {
                timestamp: utils_1.monotonicTime(),
                type: 'navigation',
                contextId: this._contextId,
                pageId,
                url: navigationEvent.url,
                sameDocument: !navigationEvent.newDocument,
            };
            this._appendTraceEvent(event);
        });
        page.on(page_1.Page.Events.Load, () => {
            if (this._disposed || page.mainFrame().url() === 'about:blank')
                return;
            const event = {
                timestamp: utils_1.monotonicTime(),
                type: 'load',
                contextId: this._contextId,
                pageId,
            };
            this._appendTraceEvent(event);
        });
        page.once(page_1.Page.Events.Close, () => {
            if (this._disposed)
                return;
            const event = {
                timestamp: utils_1.monotonicTime(),
                type: 'page-destroyed',
                contextId: this._contextId,
                pageId,
            };
            this._appendTraceEvent(event);
        });
    }
    async dispose() {
        this._disposed = true;
        helper_1.helper.removeEventListeners(this._eventListeners);
        this._snapshotter.dispose();
        const event = {
            timestamp: utils_1.monotonicTime(),
            type: 'context-destroyed',
            contextId: this._contextId,
        };
        this._appendTraceEvent(event);
        // Ensure all writes are finished.
        await this._appendEventChain;
        await this._writeArtifactChain;
    }
    _writeArtifact(sha1, buffer) {
        // Save all write promises to wait for them in dispose.
        const promise = this._innerWriteArtifact(sha1, buffer);
        this._writeArtifactChain = this._writeArtifactChain.then(() => promise);
    }
    async _innerWriteArtifact(sha1, buffer) {
        const traceDirectory = await this._traceStoragePromise;
        const filePath = path_1.default.join(traceDirectory, sha1);
        try {
            await fsAccessAsync(filePath);
        }
        catch (e) {
            // File does not exist - write it.
            await fsWriteFileAsync(filePath, buffer);
        }
    }
    _appendTraceEvent(event) {
        // Serialize all writes to the trace file.
        this._appendEventChain = this._appendEventChain.then(async (traceFile) => {
            await fsAppendFileAsync(traceFile, JSON.stringify(event) + '\n');
            return traceFile;
        });
    }
}
//# sourceMappingURL=tracer.js.map
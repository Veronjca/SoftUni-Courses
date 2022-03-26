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
exports.showTraceViewer = void 0;
const fs_1 = __importDefault(require("fs"));
const path_1 = __importDefault(require("path"));
const playwright = __importStar(require("../../.."));
const util = __importStar(require("util"));
const screenshotGenerator_1 = require("./screenshotGenerator");
const traceModel_1 = require("./traceModel");
const snapshotServer_1 = require("./snapshotServer");
const traceServer_1 = require("./traceServer");
const fsReadFileAsync = util.promisify(fs_1.default.readFile.bind(fs_1.default));
const emptyModel = {
    contexts: [
        {
            startTime: 0,
            endTime: 1,
            created: {
                timestamp: Date.now(),
                type: 'context-created',
                browserName: 'none',
                contextId: '<empty>',
                deviceScaleFactor: 1,
                isMobile: false,
                viewportSize: { width: 800, height: 600 },
                snapshotScript: '',
            },
            destroyed: {
                timestamp: Date.now(),
                type: 'context-destroyed',
                contextId: '<empty>',
            },
            name: '<empty>',
            filePath: '',
            pages: [],
        }
    ]
};
class TraceViewer {
    async load(traceDir) {
        const resourcesDir = path_1.default.join(traceDir, 'resources');
        const model = { contexts: [] };
        this._document = {
            model,
            resourcesDir,
        };
        for (const name of fs_1.default.readdirSync(traceDir)) {
            if (!name.endsWith('.trace'))
                continue;
            const filePath = path_1.default.join(traceDir, name);
            const traceContent = await fsReadFileAsync(filePath, 'utf8');
            const events = traceContent.split('\n').map(line => line.trim()).filter(line => !!line).map(line => JSON.parse(line));
            traceModel_1.readTraceFile(events, model, filePath);
        }
    }
    async show() {
        const browser = await playwright.chromium.launch({ headless: false });
        // Served by TraceServer
        // - "/tracemodel" - json with trace model.
        //
        // Served by TraceViewer
        // - "/traceviewer/..." - our frontend.
        // - "/file?filePath" - local files, used by sources tab.
        // - "/action-preview/..." - lazily generated action previews.
        // - "/sha1/<sha1>" - trace resource bodies, used by network previews.
        //
        // Served by SnapshotServer
        // - "/resources/<resourceId>" - network resources from the trace.
        // - "/snapshot/" - root for snapshot frame.
        // - "/snapshot/pageId/..." - actual snapshot html.
        // - "/snapshot/service-worker.js" - service worker that intercepts snapshot resources
        //   and translates them into "/resources/<resourceId>".
        const server = new traceServer_1.TraceServer(this._document ? this._document.model : emptyModel);
        const snapshotServer = new snapshotServer_1.SnapshotServer(server, this._document ? this._document.model : emptyModel, this._document ? this._document.resourcesDir : undefined);
        const screenshotGenerator = this._document ? new screenshotGenerator_1.ScreenshotGenerator(snapshotServer, this._document.resourcesDir, this._document.model) : undefined;
        const traceViewerHandler = (request, response) => {
            const relativePath = request.url.substring('/traceviewer/'.length);
            const absolutePath = path_1.default.join(__dirname, '..', '..', 'web', ...relativePath.split('/'));
            return server.serveFile(response, absolutePath);
        };
        server.routePrefix('/traceviewer/', traceViewerHandler, true);
        const actionPreviewHandler = (request, response) => {
            if (!screenshotGenerator)
                return false;
            const fullPath = request.url.substring('/action-preview/'.length);
            const actionId = fullPath.substring(0, fullPath.indexOf('.png'));
            screenshotGenerator.generateScreenshot(actionId).then(body => {
                if (!body) {
                    response.statusCode = 404;
                    response.end();
                }
                else {
                    response.statusCode = 200;
                    response.setHeader('Content-Type', 'image/png');
                    response.setHeader('Content-Length', body.byteLength);
                    response.end(body);
                }
            });
            return true;
        };
        server.routePrefix('/action-preview/', actionPreviewHandler);
        const fileHandler = (request, response) => {
            try {
                const url = new URL('http://localhost' + request.url);
                const search = url.search;
                if (search[0] !== '?')
                    return false;
                return server.serveFile(response, search.substring(1));
            }
            catch (e) {
                return false;
            }
        };
        server.routePath('/file', fileHandler);
        const sha1Handler = (request, response) => {
            if (!this._document)
                return false;
            const sha1 = request.url.substring('/sha1/'.length);
            if (sha1.includes('/'))
                return false;
            return server.serveFile(response, path_1.default.join(this._document.resourcesDir, sha1));
        };
        server.routePrefix('/sha1/', sha1Handler);
        const urlPrefix = await server.start();
        const uiPage = await browser.newPage({ viewport: null });
        uiPage.on('close', () => process.exit(0));
        await uiPage.goto(urlPrefix + '/traceviewer/traceViewer/index.html');
    }
}
async function showTraceViewer(traceDir) {
    const traceViewer = new TraceViewer();
    if (traceDir)
        await traceViewer.load(traceDir);
    await traceViewer.show();
}
exports.showTraceViewer = showTraceViewer;
//# sourceMappingURL=traceViewer.js.map
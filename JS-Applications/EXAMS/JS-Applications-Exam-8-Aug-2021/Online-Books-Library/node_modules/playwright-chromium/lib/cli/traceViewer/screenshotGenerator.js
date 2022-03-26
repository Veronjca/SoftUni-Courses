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
exports.ScreenshotGenerator = void 0;
const fs_1 = __importDefault(require("fs"));
const path_1 = __importDefault(require("path"));
const playwright = __importStar(require("../../.."));
const util = __importStar(require("util"));
const traceModel_1 = require("./traceModel");
const fsReadFileAsync = util.promisify(fs_1.default.readFile.bind(fs_1.default));
const fsWriteFileAsync = util.promisify(fs_1.default.writeFile.bind(fs_1.default));
class ScreenshotGenerator {
    constructor(snapshotServer, resourcesDir, traceModel) {
        this._rendering = new Map();
        this._lock = new Lock(3);
        this._snapshotServer = snapshotServer;
        this._resourcesDir = resourcesDir;
        this._traceModel = traceModel;
        this._browserPromise = playwright.chromium.launch();
    }
    generateScreenshot(actionId) {
        const { context, action } = traceModel_1.actionById(this._traceModel, actionId);
        if (!this._rendering.has(action)) {
            this._rendering.set(action, this._render(context, action).then(body => {
                this._rendering.delete(action);
                return body;
            }));
        }
        return this._rendering.get(action);
    }
    async _render(contextEntry, actionEntry) {
        const imageFileName = path_1.default.join(this._resourcesDir, actionEntry.action.timestamp + '-screenshot.png');
        try {
            return await fsReadFileAsync(imageFileName);
        }
        catch (e) {
            // fall through
        }
        const { action } = actionEntry;
        const browser = await this._browserPromise;
        await this._lock.obtain();
        const page = await browser.newPage({
            viewport: contextEntry.created.viewportSize,
            deviceScaleFactor: contextEntry.created.deviceScaleFactor
        });
        try {
            await page.goto(this._snapshotServer.snapshotRootUrl());
            const snapshots = action.snapshots || [];
            const snapshotId = snapshots.length ? snapshots[0].snapshotId : undefined;
            const snapshotUrl = this._snapshotServer.snapshotUrl(action.pageId, snapshotId, action.endTime);
            console.log('Generating screenshot for ' + action.method); // eslint-disable-line no-console
            await page.evaluate(snapshotUrl => window.showSnapshot(snapshotUrl), snapshotUrl);
            try {
                const element = await page.$(action.params.selector || '*[__playwright_target__]');
                if (element) {
                    await element.evaluate(e => {
                        e.style.backgroundColor = '#ff69b460';
                    });
                }
            }
            catch (e) {
                console.log(e); // eslint-disable-line no-console
            }
            const imageData = await page.screenshot();
            await fsWriteFileAsync(imageFileName, imageData);
            return imageData;
        }
        catch (e) {
            console.log(e); // eslint-disable-line no-console
        }
        finally {
            await page.close();
            this._lock.release();
        }
    }
}
exports.ScreenshotGenerator = ScreenshotGenerator;
class Lock {
    constructor(maxWorkers) {
        this._callbacks = [];
        this._workers = 0;
        this._maxWorkers = maxWorkers;
    }
    async obtain() {
        while (this._workers === this._maxWorkers)
            await new Promise(f => this._callbacks.push(f));
        ++this._workers;
    }
    release() {
        --this._workers;
        const callbacks = this._callbacks;
        this._callbacks = [];
        for (const callback of callbacks)
            callback();
    }
}
//# sourceMappingURL=screenshotGenerator.js.map
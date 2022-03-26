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
exports.Download = void 0;
const path_1 = __importDefault(require("path"));
const fs_1 = __importDefault(require("fs"));
const util = __importStar(require("util"));
const page_1 = require("./page");
const utils_1 = require("../utils/utils");
class Download {
    constructor(page, downloadsPath, uuid, url, suggestedFilename) {
        this._saveCallbacks = [];
        this._finished = false;
        this._failure = null;
        this._deleted = false;
        this._page = page;
        this._downloadsPath = downloadsPath;
        this._uuid = uuid;
        this._url = url;
        this._suggestedFilename = suggestedFilename;
        this._finishedCallback = () => { };
        this._finishedPromise = new Promise(f => this._finishedCallback = f);
        page._browserContext._downloads.add(this);
        this._acceptDownloads = !!this._page._browserContext._options.acceptDownloads;
        if (suggestedFilename !== undefined)
            this._page.emit(page_1.Page.Events.Download, this);
    }
    _filenameSuggested(suggestedFilename) {
        utils_1.assert(this._suggestedFilename === undefined);
        this._suggestedFilename = suggestedFilename;
        this._page.emit(page_1.Page.Events.Download, this);
    }
    url() {
        return this._url;
    }
    suggestedFilename() {
        return this._suggestedFilename;
    }
    async localPath() {
        if (!this._acceptDownloads)
            throw new Error('Pass { acceptDownloads: true } when you are creating your browser context.');
        const fileName = path_1.default.join(this._downloadsPath, this._uuid);
        await this._finishedPromise;
        if (this._failure)
            return null;
        return fileName;
    }
    saveAs(saveCallback) {
        if (!this._acceptDownloads)
            throw new Error('Pass { acceptDownloads: true } when you are creating your browser context.');
        if (this._deleted)
            throw new Error('Download already deleted. Save before deleting.');
        if (this._failure)
            throw new Error('Download not found on disk. Check download.failure() for details.');
        if (this._finished) {
            saveCallback(path_1.default.join(this._downloadsPath, this._uuid));
            return;
        }
        this._saveCallbacks.push(saveCallback);
    }
    async failure() {
        if (!this._acceptDownloads)
            return 'Pass { acceptDownloads: true } when you are creating your browser context.';
        await this._finishedPromise;
        return this._failure;
    }
    async delete() {
        if (!this._acceptDownloads)
            return;
        const fileName = await this.localPath();
        if (this._deleted)
            return;
        this._deleted = true;
        if (fileName)
            await util.promisify(fs_1.default.unlink)(fileName).catch(e => { });
    }
    async deleteOnContextClose() {
        // Compared to "delete", this method does not wait for the download to finish.
        // We use it when closing the context to avoid stalling.
        if (this._deleted)
            return;
        this._deleted = true;
        if (this._acceptDownloads) {
            const fileName = path_1.default.join(this._downloadsPath, this._uuid);
            await util.promisify(fs_1.default.unlink)(fileName).catch(e => { });
        }
        this._reportFinished('Download deleted upon browser context closure.');
    }
    async _reportFinished(error) {
        if (this._finished)
            return;
        this._finished = true;
        this._failure = error || null;
        if (error) {
            for (const callback of this._saveCallbacks)
                callback('', error);
        }
        else {
            const fullPath = path_1.default.join(this._downloadsPath, this._uuid);
            for (const callback of this._saveCallbacks)
                await callback(fullPath);
        }
        this._saveCallbacks = [];
        this._finishedCallback();
    }
}
exports.Download = Download;
//# sourceMappingURL=download.js.map
"use strict";
/**
 * Copyright (c) Microsoft Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the 'License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
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
exports.DownloadDispatcher = void 0;
const dispatcher_1 = require("./dispatcher");
const streamDispatcher_1 = require("./streamDispatcher");
const fs_1 = __importDefault(require("fs"));
const util = __importStar(require("util"));
const utils_1 = require("../utils/utils");
class DownloadDispatcher extends dispatcher_1.Dispatcher {
    constructor(scope, download) {
        super(scope, download, 'Download', {
            url: download.url(),
            suggestedFilename: download.suggestedFilename(),
        });
    }
    async path() {
        const path = await this._object.localPath();
        return { value: path || undefined };
    }
    async saveAs(params) {
        return await new Promise((resolve, reject) => {
            this._object.saveAs(async (localPath, error) => {
                if (error !== undefined) {
                    reject(new Error(error));
                    return;
                }
                try {
                    await utils_1.mkdirIfNeeded(params.path);
                    await util.promisify(fs_1.default.copyFile)(localPath, params.path);
                    resolve();
                }
                catch (e) {
                    reject(e);
                }
            });
        });
    }
    async saveAsStream() {
        return await new Promise((resolve, reject) => {
            this._object.saveAs(async (localPath, error) => {
                if (error !== undefined) {
                    reject(new Error(error));
                    return;
                }
                try {
                    const readable = fs_1.default.createReadStream(localPath);
                    await new Promise(f => readable.on('readable', f));
                    const stream = new streamDispatcher_1.StreamDispatcher(this._scope, readable);
                    // Resolve with a stream, so that client starts saving the data.
                    resolve({ stream });
                    // Block the download until the stream is consumed.
                    await new Promise(resolve => {
                        readable.on('close', resolve);
                        readable.on('end', resolve);
                        readable.on('error', resolve);
                    });
                }
                catch (e) {
                    reject(e);
                }
            });
        });
    }
    async stream() {
        const fileName = await this._object.localPath();
        if (!fileName)
            return {};
        const readable = fs_1.default.createReadStream(fileName);
        await new Promise(f => readable.on('readable', f));
        return { stream: new streamDispatcher_1.StreamDispatcher(this._scope, readable) };
    }
    async failure() {
        const error = await this._object.failure();
        return { error: error || undefined };
    }
    async delete() {
        await this._object.delete();
    }
}
exports.DownloadDispatcher = DownloadDispatcher;
//# sourceMappingURL=downloadDispatcher.js.map
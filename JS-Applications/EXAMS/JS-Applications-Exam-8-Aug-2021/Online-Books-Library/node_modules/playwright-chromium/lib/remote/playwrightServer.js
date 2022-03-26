"use strict";
/**
 * Copyright (c) Microsoft Corporation.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
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
exports.PlaywrightServer = void 0;
const debug_1 = __importDefault(require("debug"));
const http = __importStar(require("http"));
const ws_1 = __importDefault(require("ws"));
const dispatcher_1 = require("../dispatchers/dispatcher");
const playwrightDispatcher_1 = require("../dispatchers/playwrightDispatcher");
const playwright_1 = require("../server/playwright");
const processLauncher_1 = require("../server/processLauncher");
const debugLog = debug_1.default('pw:server');
class PlaywrightServer {
    listen(port) {
        this._server = http.createServer((request, response) => {
            response.end('Running');
        });
        this._server.on('error', error => debugLog(error));
        this._server.listen(port);
        debugLog('Listening on ' + port);
        const wsServer = new ws_1.default.Server({ server: this._server, path: '/ws' });
        wsServer.on('connection', async (ws) => {
            if (this._client) {
                ws.close();
                return;
            }
            this._client = ws;
            debugLog('Incoming connection');
            const dispatcherConnection = new dispatcher_1.DispatcherConnection();
            ws.on('message', message => dispatcherConnection.dispatch(JSON.parse(message.toString())));
            ws.on('close', () => {
                debugLog('Client closed');
                this._onDisconnect();
            });
            ws.on('error', error => {
                debugLog('Client error ' + error);
                this._onDisconnect();
            });
            dispatcherConnection.onmessage = message => ws.send(JSON.stringify(message));
            new playwrightDispatcher_1.PlaywrightDispatcher(dispatcherConnection.rootDispatcher(), playwright_1.createPlaywright());
        });
    }
    async close() {
        if (!this._server)
            return;
        debugLog('Closing server');
        await new Promise(f => this._server.close(f));
        await processLauncher_1.gracefullyCloseAll();
    }
    async _onDisconnect() {
        await processLauncher_1.gracefullyCloseAll();
        this._client = undefined;
    }
}
exports.PlaywrightServer = PlaywrightServer;
//# sourceMappingURL=playwrightServer.js.map
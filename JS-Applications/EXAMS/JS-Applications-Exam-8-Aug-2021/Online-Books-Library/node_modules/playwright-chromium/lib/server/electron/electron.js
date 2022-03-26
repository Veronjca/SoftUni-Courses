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
Object.defineProperty(exports, "__esModule", { value: true });
exports.Electron = exports.ElectronApplication = void 0;
const os = __importStar(require("os"));
const crBrowser_1 = require("../chromium/crBrowser");
const crConnection_1 = require("../chromium/crConnection");
const crExecutionContext_1 = require("../chromium/crExecutionContext");
const js = __importStar(require("../javascript"));
const page_1 = require("../page");
const timeoutSettings_1 = require("../../utils/timeoutSettings");
const transport_1 = require("../transport");
const processLauncher_1 = require("../processLauncher");
const browserContext_1 = require("../browserContext");
const progress_1 = require("../progress");
const helper_1 = require("../helper");
const readline = __importStar(require("readline"));
const debugLogger_1 = require("../../utils/debugLogger");
const instrumentation_1 = require("../instrumentation");
class ElectronApplication extends instrumentation_1.SdkObject {
    constructor(parent, browser, nodeConnection) {
        super(parent);
        this._windows = new Set();
        this._lastWindowId = 0;
        this._timeoutSettings = new timeoutSettings_1.TimeoutSettings();
        this._browserContext = browser._defaultContext;
        this._browserContext.on(browserContext_1.BrowserContext.Events.Close, () => {
            // Emit application closed after context closed.
            Promise.resolve().then(() => this.emit(ElectronApplication.Events.Close));
        });
        this._browserContext.on(browserContext_1.BrowserContext.Events.Page, event => this._onPage(event));
        this._nodeConnection = nodeConnection;
        this._nodeSession = nodeConnection.rootSession;
    }
    async _onPage(page) {
        // Needs to be sync.
        const windowId = ++this._lastWindowId;
        page.on(page_1.Page.Events.Close, () => {
            page.browserWindow.dispose();
            this._windows.delete(page);
        });
        page._browserWindowId = windowId;
        this._windows.add(page);
        // Below is async.
        const handle = await this._nodeElectronHandle.evaluateHandle(({ BrowserWindow }, windowId) => BrowserWindow.fromId(windowId), windowId).catch(e => { });
        if (!handle)
            return;
        page.browserWindow = handle;
        const controller = new progress_1.ProgressController(instrumentation_1.internalCallMetadata(), this);
        await controller.run(progress => page.mainFrame()._waitForLoadState(progress, 'domcontentloaded'), page._timeoutSettings.navigationTimeout({})).catch(e => { }); // can happen after detach
        this.emit(ElectronApplication.Events.Window, page);
    }
    context() {
        return this._browserContext;
    }
    async close() {
        const closed = this._waitForEvent(ElectronApplication.Events.Close);
        await this._nodeElectronHandle.evaluate(({ app }) => app.quit());
        this._nodeConnection.close();
        await closed;
    }
    async _waitForEvent(event, predicate) {
        const progressController = new progress_1.ProgressController(instrumentation_1.internalCallMetadata(), this);
        if (event !== ElectronApplication.Events.Close)
            this._browserContext._closePromise.then(error => progressController.abort(error));
        return progressController.run(progress => helper_1.helper.waitForEvent(progress, this, event, predicate).promise, this._timeoutSettings.timeout({}));
    }
    async _init() {
        this._nodeSession.on('Runtime.executionContextCreated', (event) => {
            if (event.context.auxData && event.context.auxData.isDefault)
                this._nodeExecutionContext = new js.ExecutionContext(this, new crExecutionContext_1.CRExecutionContext(this._nodeSession, event.context));
        });
        await this._nodeSession.send('Runtime.enable', {}).catch(e => { });
        this._nodeElectronHandle = await js.evaluate(this._nodeExecutionContext, false /* returnByValue */, `process.mainModule.require('electron')`);
    }
}
exports.ElectronApplication = ElectronApplication;
ElectronApplication.Events = {
    Close: 'close',
    Window: 'window',
};
class Electron extends instrumentation_1.SdkObject {
    constructor(playwrightOptions) {
        super(playwrightOptions.rootSdkObject);
        this._playwrightOptions = playwrightOptions;
    }
    async launch(options) {
        const { args = [], } = options;
        const controller = new progress_1.ProgressController(instrumentation_1.internalCallMetadata(), this);
        controller.setLogName('browser');
        return controller.run(async (progress) => {
            let app = undefined;
            const electronArguments = ['--inspect=0', '--remote-debugging-port=0', ...args];
            if (os.platform() === 'linux') {
                const runningAsRoot = process.geteuid && process.geteuid() === 0;
                if (runningAsRoot && electronArguments.indexOf('--no-sandbox') === -1)
                    electronArguments.push('--no-sandbox');
            }
            const browserLogsCollector = new debugLogger_1.RecentLogsCollector();
            const { launchedProcess, gracefullyClose, kill } = await processLauncher_1.launchProcess({
                executablePath: options.executablePath || require('electron/index.js'),
                args: electronArguments,
                env: options.env ? processLauncher_1.envArrayToObject(options.env) : process.env,
                log: (message) => {
                    progress.log(message);
                    browserLogsCollector.log(message);
                },
                stdio: 'pipe',
                cwd: options.cwd,
                tempDirectories: [],
                attemptToGracefullyClose: () => app.close(),
                handleSIGINT: true,
                handleSIGTERM: true,
                handleSIGHUP: true,
                onExit: () => { },
            });
            const nodeMatch = await waitForLine(progress, launchedProcess, /^Debugger listening on (ws:\/\/.*)$/);
            const nodeTransport = await transport_1.WebSocketTransport.connect(progress, nodeMatch[1]);
            const nodeConnection = new crConnection_1.CRConnection(nodeTransport, helper_1.helper.debugProtocolLogger(), browserLogsCollector);
            const chromeMatch = await waitForLine(progress, launchedProcess, /^DevTools listening on (ws:\/\/.*)$/);
            const chromeTransport = await transport_1.WebSocketTransport.connect(progress, chromeMatch[1]);
            const browserProcess = {
                onclose: undefined,
                process: launchedProcess,
                close: gracefullyClose,
                kill
            };
            const browserOptions = {
                ...this._playwrightOptions,
                name: 'electron',
                isChromium: true,
                headful: true,
                persistent: { sdkLanguage: options.sdkLanguage, noDefaultViewport: true },
                browserProcess,
                protocolLogger: helper_1.helper.debugProtocolLogger(),
                browserLogsCollector,
            };
            const browser = await crBrowser_1.CRBrowser.connect(chromeTransport, browserOptions);
            app = new ElectronApplication(this, browser, nodeConnection);
            await app._init();
            return app;
        }, timeoutSettings_1.TimeoutSettings.timeout(options));
    }
}
exports.Electron = Electron;
function waitForLine(progress, process, regex) {
    return new Promise((resolve, reject) => {
        const rl = readline.createInterface({ input: process.stderr });
        const failError = new Error('Process failed to launch!');
        const listeners = [
            helper_1.helper.addEventListener(rl, 'line', onLine),
            helper_1.helper.addEventListener(rl, 'close', reject.bind(null, failError)),
            helper_1.helper.addEventListener(process, 'exit', reject.bind(null, failError)),
            // It is Ok to remove error handler because we did not create process and there is another listener.
            helper_1.helper.addEventListener(process, 'error', reject.bind(null, failError))
        ];
        progress.cleanupWhenAborted(cleanup);
        function onLine(line) {
            const match = line.match(regex);
            if (!match)
                return;
            cleanup();
            resolve(match);
        }
        function cleanup() {
            helper_1.helper.removeEventListeners(listeners);
        }
    });
}
//# sourceMappingURL=electron.js.map
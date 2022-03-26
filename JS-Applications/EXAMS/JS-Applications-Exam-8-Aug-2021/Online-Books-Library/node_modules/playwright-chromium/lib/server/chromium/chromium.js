"use strict";
/**
 * Copyright 2017 Google Inc. All rights reserved.
 * Modifications copyright (c) Microsoft Corporation.
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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Chromium = void 0;
const path_1 = __importDefault(require("path"));
const crBrowser_1 = require("./crBrowser");
const crConnection_1 = require("./crConnection");
const stackTrace_1 = require("../../utils/stackTrace");
const browserType_1 = require("../browserType");
const transport_1 = require("../transport");
const crDevTools_1 = require("./crDevTools");
const utils_1 = require("../../utils/utils");
const debugLogger_1 = require("../../utils/debugLogger");
const progress_1 = require("../progress");
const timeoutSettings_1 = require("../../utils/timeoutSettings");
const helper_1 = require("../helper");
class Chromium extends browserType_1.BrowserType {
    constructor(playwrightOptions) {
        super('chromium', playwrightOptions);
        if (utils_1.isDebugMode())
            this._devtools = this._createDevTools();
    }
    async connectOverCDP(metadata, wsEndpoint, options, timeout) {
        const controller = new progress_1.ProgressController(metadata, this);
        controller.setLogName('browser');
        const browserLogsCollector = new debugLogger_1.RecentLogsCollector();
        return controller.run(async (progress) => {
            const chromeTransport = await transport_1.WebSocketTransport.connect(progress, wsEndpoint);
            const browserProcess = {
                close: async () => {
                    await chromeTransport.closeAndWait();
                },
                kill: async () => {
                    await chromeTransport.closeAndWait();
                }
            };
            const browserOptions = {
                ...this._playwrightOptions,
                slowMo: options.slowMo,
                name: 'chromium',
                isChromium: true,
                persistent: { sdkLanguage: options.sdkLanguage, noDefaultViewport: true },
                browserProcess,
                protocolLogger: helper_1.helper.debugProtocolLogger(),
                browserLogsCollector,
            };
            return await crBrowser_1.CRBrowser.connect(chromeTransport, browserOptions);
        }, timeoutSettings_1.TimeoutSettings.timeout({ timeout }));
    }
    _createDevTools() {
        return new crDevTools_1.CRDevTools(path_1.default.join(this._registry.browserDirectory('chromium'), 'devtools-preferences.json'));
    }
    async _connectToTransport(transport, options) {
        let devtools = this._devtools;
        if (options.__testHookForDevTools) {
            devtools = this._createDevTools();
            await options.__testHookForDevTools(devtools);
        }
        return crBrowser_1.CRBrowser.connect(transport, options, devtools);
    }
    _rewriteStartupError(error) {
        // These error messages are taken from Chromium source code as of July, 2020:
        // https://github.com/chromium/chromium/blob/70565f67e79f79e17663ad1337dc6e63ee207ce9/content/browser/zygote_host/zygote_host_impl_linux.cc
        if (!error.message.includes('crbug.com/357670') && !error.message.includes('No usable sandbox!') && !error.message.includes('crbug.com/638180'))
            return error;
        return stackTrace_1.rewriteErrorMessage(error, [
            `Chromium sandboxing failed!`,
            `================================`,
            `To workaround sandboxing issues, do either of the following:`,
            `  - (preferred): Configure environment to support sandboxing: https://github.com/microsoft/playwright/blob/master/docs/troubleshooting.md`,
            `  - (alternative): Launch Chromium without sandbox using 'chromiumSandbox: false' option`,
            `================================`,
            ``,
        ].join('\n'));
    }
    _amendEnvironment(env, userDataDir, executable, browserArguments) {
        return env;
    }
    _attemptToGracefullyCloseBrowser(transport) {
        const message = { method: 'Browser.close', id: crConnection_1.kBrowserCloseMessageId, params: {} };
        transport.send(message);
    }
    _defaultArgs(options, isPersistent, userDataDir) {
        const { args = [], proxy } = options;
        const userDataDirArg = args.find(arg => arg.startsWith('--user-data-dir'));
        if (userDataDirArg)
            throw new Error('Pass userDataDir parameter instead of specifying --user-data-dir argument');
        if (args.find(arg => arg.startsWith('--remote-debugging-pipe')))
            throw new Error('Playwright manages remote debugging connection itself.');
        if (args.find(arg => !arg.startsWith('-')))
            throw new Error('Arguments can not specify page to be opened');
        const chromeArguments = [...DEFAULT_ARGS];
        chromeArguments.push(`--user-data-dir=${userDataDir}`);
        if (options.useWebSocket)
            chromeArguments.push('--remote-debugging-port=0');
        else
            chromeArguments.push('--remote-debugging-pipe');
        if (options.devtools)
            chromeArguments.push('--auto-open-devtools-for-tabs');
        if (options.headless) {
            chromeArguments.push('--headless', '--hide-scrollbars', '--mute-audio', '--blink-settings=primaryHoverType=2,availableHoverTypes=2,primaryPointerType=4,availablePointerTypes=4');
        }
        if (options.chromiumSandbox !== true)
            chromeArguments.push('--no-sandbox');
        if (proxy) {
            const proxyURL = new URL(proxy.server);
            const isSocks = proxyURL.protocol === 'socks5:';
            // https://www.chromium.org/developers/design-documents/network-settings
            if (isSocks) {
                // https://www.chromium.org/developers/design-documents/network-stack/socks-proxy
                chromeArguments.push(`--host-resolver-rules="MAP * ~NOTFOUND , EXCLUDE ${proxyURL.hostname}"`);
            }
            chromeArguments.push(`--proxy-server=${proxy.server}`);
            if (proxy.bypass) {
                const patterns = proxy.bypass.split(',').map(t => t.trim()).map(t => t.startsWith('.') ? '*' + t : t);
                chromeArguments.push(`--proxy-bypass-list=${patterns.join(';')}`);
            }
        }
        chromeArguments.push(...args);
        if (isPersistent)
            chromeArguments.push('about:blank');
        else
            chromeArguments.push('--no-startup-window');
        return chromeArguments;
    }
}
exports.Chromium = Chromium;
const DEFAULT_ARGS = [
    '--disable-background-networking',
    '--enable-features=NetworkService,NetworkServiceInProcess',
    '--disable-background-timer-throttling',
    '--disable-backgrounding-occluded-windows',
    '--disable-breakpad',
    '--disable-client-side-phishing-detection',
    '--disable-component-extensions-with-background-pages',
    '--disable-default-apps',
    '--disable-dev-shm-usage',
    '--disable-extensions',
    // BlinkGenPropertyTrees disabled due to crbug.com/937609
    '--disable-features=TranslateUI,BlinkGenPropertyTrees,ImprovedCookieControls,SameSiteByDefaultCookies,LazyFrameLoading',
    '--disable-hang-monitor',
    '--disable-ipc-flooding-protection',
    '--disable-popup-blocking',
    '--disable-prompt-on-repost',
    '--disable-renderer-backgrounding',
    '--disable-sync',
    '--force-color-profile=srgb',
    '--metrics-recording-only',
    '--no-first-run',
    '--enable-automation',
    '--password-store=basic',
    '--use-mock-keychain',
];
//# sourceMappingURL=chromium.js.map
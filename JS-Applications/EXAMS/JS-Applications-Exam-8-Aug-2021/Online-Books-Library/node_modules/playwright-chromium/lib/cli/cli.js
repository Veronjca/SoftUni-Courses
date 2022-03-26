#!/usr/bin/env node
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
/* eslint-disable no-console */
const path_1 = __importDefault(require("path"));
const commander_1 = __importDefault(require("commander"));
const os_1 = __importDefault(require("os"));
const fs_1 = __importDefault(require("fs"));
const driver_1 = require("./driver");
const traceViewer_1 = require("./traceViewer/traceViewer");
const playwright = __importStar(require("../.."));
commander_1.default
    .version('Version ' + require('../../package.json').version)
    .name('npx playwright')
    .option('-b, --browser <browserType>', 'browser to use, one of cr, chromium, ff, firefox, wk, webkit', 'chromium')
    .option('--color-scheme <scheme>', 'emulate preferred color scheme, "light" or "dark"')
    .option('--device <deviceName>', 'emulate device, for example  "iPhone 11"')
    .option('--geolocation <coordinates>', 'specify geolocation coordinates, for example "37.819722,-122.478611"')
    .option('--lang <language>', 'specify language / locale, for example "en-GB"')
    .option('--load-storage <filename>', 'load context storage state from the file, previously saved with --save-storage')
    .option('--proxy-server <proxy>', 'specify proxy server, for example "http://myproxy:3128" or "socks5://myproxy:8080"')
    .option('--save-storage <filename>', 'save context storage state at the end, for later use with --load-storage')
    .option('--timezone <time zone>', 'time zone to emulate, for example "Europe/Rome"')
    .option('--timeout <timeout>', 'timeout for Playwright actions in milliseconds', '10000')
    .option('--user-agent <ua string>', 'specify user agent string')
    .option('--viewport-size <size>', 'specify browser viewport size in pixels, for example "1280, 720"');
commander_1.default
    .command('open [url]')
    .description('open page in browser specified via -b, --browser')
    .action(function (url, command) {
    open(command.parent, url, language());
}).on('--help', function () {
    console.log('');
    console.log('Examples:');
    console.log('');
    console.log('  $ open');
    console.log('  $ -b webkit open https://example.com');
});
const browsers = [
    { alias: 'cr', name: 'Chromium', type: 'chromium' },
    { alias: 'ff', name: 'Firefox', type: 'firefox' },
    { alias: 'wk', name: 'WebKit', type: 'webkit' },
];
for (const { alias, name, type } of browsers) {
    commander_1.default
        .command(`${alias} [url]`)
        .description(`open page in ${name}`)
        .option('--target <language>', `language to use, one of javascript, python, python-async, csharp`, language())
        .action(function (url, command) {
        open({ ...command.parent, browser: type }, url, command.target);
    }).on('--help', function () {
        console.log('');
        console.log('Examples:');
        console.log('');
        console.log(`  $ ${alias} https://example.com`);
    });
}
commander_1.default
    .command('codegen [url]')
    .description('open page and generate code for user actions')
    .option('-o, --output <file name>', 'saves the generated script to a file')
    .option('--target <language>', `language to use, one of javascript, python, python-async, csharp`, language())
    .action(function (url, command) {
    codegen(command.parent, url, command.target, command.output);
}).on('--help', function () {
    console.log('');
    console.log('Examples:');
    console.log('');
    console.log('  $ codegen');
    console.log('  $ codegen --target=python');
    console.log('  $ -b webkit codegen https://example.com');
});
commander_1.default
    .command('screenshot <url> <filename>')
    .description('capture a page screenshot')
    .option('--wait-for-selector <selector>', 'wait for selector before taking a screenshot')
    .option('--wait-for-timeout <timeout>', 'wait for timeout in milliseconds before taking a screenshot')
    .option('--full-page', 'whether to take a full page screenshot (entire scrollable area)')
    .action(function (url, filename, command) {
    screenshot(command.parent, command, url, filename);
}).on('--help', function () {
    console.log('');
    console.log('Examples:');
    console.log('');
    console.log('  $ -b webkit screenshot https://example.com example.png');
});
commander_1.default
    .command('pdf <url> <filename>')
    .description('save page as pdf')
    .option('--wait-for-selector <selector>', 'wait for given selector before saving as pdf')
    .option('--wait-for-timeout <timeout>', 'wait for given timeout in milliseconds before saving as pdf')
    .action(function (url, filename, command) {
    pdf(command.parent, command, url, filename);
}).on('--help', function () {
    console.log('');
    console.log('Examples:');
    console.log('');
    console.log('  $ pdf https://example.com example.pdf');
});
commander_1.default
    .command('install [browserType...]')
    .description('Ensure browsers necessary for this version of Playwright are installed')
    .action(function (browserType) {
    const allBrowsers = new Set(['chromium', 'firefox', 'webkit']);
    for (const type of browserType) {
        if (!allBrowsers.has(type)) {
            console.log(`Invalid browser name: '${type}'. Expecting 'chromium', 'firefox' or 'webkit'.`);
            process.exit(1);
        }
    }
    driver_1.installBrowsers(browserType.length ? browserType : undefined).catch((e) => {
        console.log(`Failed to install browsers\n${e}`);
        process.exit(1);
    });
});
if (process.env.PWTRACE) {
    commander_1.default
        .command('show-trace [trace]')
        .description('Show trace viewer')
        .action(function (trace, command) {
        traceViewer_1.showTraceViewer(trace);
    }).on('--help', function () {
        console.log('');
        console.log('Examples:');
        console.log('');
        console.log('  $ show-trace --resources=resources trace/file.trace');
        console.log('  $ show-trace trace/directory');
    });
}
if (process.argv[2] === 'run-driver')
    driver_1.runServer();
else if (process.argv[2] === 'print-api-json')
    driver_1.printApiJson();
else if (process.argv[2] === 'launch-server')
    driver_1.launchBrowserServer(process.argv[3], process.argv[4]);
else
    commander_1.default.parse(process.argv);
async function launchContext(options, headless) {
    validateOptions(options);
    const browserType = lookupBrowserType(options);
    const launchOptions = { headless };
    const contextOptions = 
    // Copy the device descriptor since we have to compare and modify the options.
    options.device ? { ...playwright.devices[options.device] } : {};
    // In headful mode, use host device scale factor for things to look nice.
    // In headless, keep things the way it works in Playwright by default.
    // Assume high-dpi on MacOS. TODO: this is not perfect.
    if (!headless)
        contextOptions.deviceScaleFactor = os_1.default.platform() === 'darwin' ? 2 : 1;
    // Work around the WebKit GTK scrolling issue.
    if (browserType.name() === 'webkit' && process.platform === 'linux') {
        delete contextOptions.hasTouch;
        delete contextOptions.isMobile;
    }
    if (contextOptions.isMobile && browserType.name() === 'firefox')
        contextOptions.isMobile = undefined;
    if (process.env.PWTRACE)
        contextOptions._traceDir = path_1.default.join(process.cwd(), '.trace');
    // Proxy
    if (options.proxyServer) {
        launchOptions.proxy = {
            server: options.proxyServer
        };
    }
    const browser = await browserType.launch(launchOptions);
    // Viewport size
    if (options.viewportSize) {
        try {
            const [width, height] = options.viewportSize.split(',').map(n => parseInt(n, 10));
            contextOptions.viewport = { width, height };
        }
        catch (e) {
            console.log('Invalid window size format: use "width, height", for example --window-size=800,600');
            process.exit(0);
        }
    }
    // Geolocation
    if (options.geolocation) {
        try {
            const [latitude, longitude] = options.geolocation.split(',').map(n => parseFloat(n.trim()));
            contextOptions.geolocation = {
                latitude,
                longitude
            };
        }
        catch (e) {
            console.log('Invalid geolocation format: user lat, long, for example --geolocation="37.819722,-122.478611"');
            process.exit(0);
        }
        contextOptions.permissions = ['geolocation'];
    }
    // User agent
    if (options.userAgent)
        contextOptions.userAgent = options.userAgent;
    // Lang
    if (options.lang)
        contextOptions.locale = options.lang;
    // Color scheme
    if (options.colorScheme)
        contextOptions.colorScheme = options.colorScheme;
    // Timezone
    if (options.timezone)
        contextOptions.timezoneId = options.timezone;
    // Storage
    if (options.loadStorage)
        contextOptions.storageState = options.loadStorage;
    // Close app when the last window closes.
    const context = await browser.newContext(contextOptions);
    let closingBrowser = false;
    async function closeBrowser() {
        // We can come here multiple times. For example, saving storage creates
        // a temporary page and we call closeBrowser again when that page closes.
        if (closingBrowser)
            return;
        closingBrowser = true;
        if (options.saveStorage)
            await context.storageState({ path: options.saveStorage }).catch(e => null);
        await browser.close();
    }
    context.on('page', page => {
        page.on('dialog', () => { }); // Prevent dialogs from being automatically dismissed.
        page.on('close', () => {
            const hasPage = browser.contexts().some(context => context.pages().length > 0);
            if (hasPage)
                return;
            // Avoid the error when the last page is closed because the browser has been closed.
            closeBrowser().catch(e => null);
        });
    });
    if (options.timeout) {
        context.setDefaultTimeout(parseInt(options.timeout, 10));
        context.setDefaultNavigationTimeout(parseInt(options.timeout, 10));
    }
    // Omit options that we add automatically for presentation purpose.
    delete launchOptions.headless;
    delete contextOptions.deviceScaleFactor;
    return { browser, browserName: browserType.name(), context, contextOptions, launchOptions };
}
async function openPage(context, url) {
    const page = await context.newPage();
    if (url) {
        if (fs_1.default.existsSync(url))
            url = 'file://' + path_1.default.resolve(url);
        else if (!url.startsWith('http') && !url.startsWith('file://') && !url.startsWith('about:'))
            url = 'http://' + url;
        await page.goto(url);
    }
    return page;
}
async function open(options, url, language) {
    const { context, launchOptions, contextOptions } = await launchContext(options, !!process.env.PWCLI_HEADLESS_FOR_TEST);
    await context._enableRecorder({
        language,
        launchOptions,
        contextOptions,
        device: options.device,
        saveStorage: options.saveStorage,
    });
    await openPage(context, url);
    if (process.env.PWCLI_EXIT_FOR_TEST)
        await Promise.all(context.pages().map(p => p.close()));
}
async function codegen(options, url, language, outputFile) {
    const { context, launchOptions, contextOptions } = await launchContext(options, !!process.env.PWCLI_HEADLESS_FOR_TEST);
    if (process.env.PWTRACE)
        contextOptions._traceDir = path_1.default.join(process.cwd(), '.trace');
    await context._enableRecorder({
        language,
        launchOptions,
        contextOptions,
        device: options.device,
        saveStorage: options.saveStorage,
        startRecording: true,
        outputFile: outputFile ? path_1.default.resolve(outputFile) : undefined
    });
    await openPage(context, url);
    if (process.env.PWCLI_EXIT_FOR_TEST)
        await Promise.all(context.pages().map(p => p.close()));
}
async function waitForPage(page, captureOptions) {
    if (captureOptions.waitForSelector) {
        console.log(`Waiting for selector ${captureOptions.waitForSelector}...`);
        await page.waitForSelector(captureOptions.waitForSelector);
    }
    if (captureOptions.waitForTimeout) {
        console.log(`Waiting for timeout ${captureOptions.waitForTimeout}...`);
        await page.waitForTimeout(parseInt(captureOptions.waitForTimeout, 10));
    }
}
async function screenshot(options, captureOptions, url, path) {
    const { browser, context } = await launchContext(options, true);
    console.log('Navigating to ' + url);
    const page = await openPage(context, url);
    await waitForPage(page, captureOptions);
    console.log('Capturing screenshot into ' + path);
    await page.screenshot({ path, fullPage: !!captureOptions.fullPage });
    await browser.close();
}
async function pdf(options, captureOptions, url, path) {
    if (options.browser !== 'chromium') {
        console.error('PDF creation is only working with Chromium');
        process.exit(1);
    }
    const { browser, context } = await launchContext({ ...options, browser: 'chromium' }, true);
    console.log('Navigating to ' + url);
    const page = await openPage(context, url);
    await waitForPage(page, captureOptions);
    console.log('Saving as pdf into ' + path);
    await page.pdf({ path });
    await browser.close();
}
function lookupBrowserType(options) {
    let name = options.browser;
    if (options.device) {
        const device = playwright.devices[options.device];
        name = device.defaultBrowserType;
    }
    let browserType;
    switch (name) {
        case 'chromium':
            browserType = playwright.chromium;
            break;
        case 'webkit':
            browserType = playwright.webkit;
            break;
        case 'firefox':
            browserType = playwright.firefox;
            break;
        case 'cr':
            browserType = playwright.chromium;
            break;
        case 'wk':
            browserType = playwright.webkit;
            break;
        case 'ff':
            browserType = playwright.firefox;
            break;
    }
    if (browserType)
        return browserType;
    commander_1.default.help();
}
function validateOptions(options) {
    if (options.device && !(options.device in playwright.devices)) {
        console.log(`Device descriptor not found: '${options.device}', available devices are:`);
        for (const name in playwright.devices)
            console.log(`  "${name}"`);
        process.exit(0);
    }
    if (options.colorScheme && !['light', 'dark'].includes(options.colorScheme)) {
        console.log('Invalid color scheme, should be one of "light", "dark"');
        process.exit(0);
    }
}
function language() {
    return process.env.PW_CLI_TARGET_LANG || 'javascript';
}
//# sourceMappingURL=cli.js.map
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
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.createPlaywright = exports.Playwright = void 0;
const path_1 = __importDefault(require("path"));
const tracer_1 = require("../trace/tracer");
const android_1 = require("./android/android");
const backendAdb_1 = require("./android/backendAdb");
const chromium_1 = require("./chromium/chromium");
const electron_1 = require("./electron/electron");
const firefox_1 = require("./firefox/firefox");
const selectors_1 = require("./selectors");
const harTracer_1 = require("./supplements/har/harTracer");
const inspectorController_1 = require("./supplements/inspectorController");
const webkit_1 = require("./webkit/webkit");
const registry_1 = require("../utils/registry");
const instrumentation_1 = require("./instrumentation");
class Playwright extends instrumentation_1.SdkObject {
    constructor(isInternal) {
        const listeners = [];
        if (!isInternal) {
            listeners.push(new tracer_1.Tracer());
            listeners.push(new harTracer_1.HarTracer());
            listeners.push(new inspectorController_1.InspectorController());
        }
        const instrumentation = instrumentation_1.multiplexInstrumentation(listeners);
        super({ attribution: {}, instrumentation });
        this.options = {
            registry: new registry_1.Registry(path_1.default.join(__dirname, '..', '..')),
            rootSdkObject: this,
        };
        this.chromium = new chromium_1.Chromium(this.options);
        this.firefox = new firefox_1.Firefox(this.options);
        this.webkit = new webkit_1.WebKit(this.options);
        this.electron = new electron_1.Electron(this.options);
        this.android = new android_1.Android(new backendAdb_1.AdbBackend(), this.options);
        this.selectors = selectors_1.serverSelectors;
    }
}
exports.Playwright = Playwright;
function createPlaywright(isInternal = false) {
    return new Playwright(isInternal);
}
exports.createPlaywright = createPlaywright;
//# sourceMappingURL=playwright.js.map
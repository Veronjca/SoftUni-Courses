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
Object.defineProperty(exports, "__esModule", { value: true });
exports.InspectorController = void 0;
const recorderSupplement_1 = require("./recorderSupplement");
const debugLogger_1 = require("../../utils/debugLogger");
const utils_1 = require("../../utils/utils");
class InspectorController {
    constructor() {
        this._waitOperations = new Map();
    }
    async onContextCreated(context) {
        if (utils_1.isDebugMode())
            recorderSupplement_1.RecorderSupplement.getOrCreate(context, { pauseOnNextStatement: true });
    }
    async onBeforeCall(sdkObject, metadata) {
        var _a, _b;
        const context = sdkObject.attribution.context;
        if (!context)
            return;
        // Process logs for waitForNavigation/waitForLoadState
        if ((_b = (_a = metadata.params) === null || _a === void 0 ? void 0 : _a.info) === null || _b === void 0 ? void 0 : _b.waitId) {
            const info = metadata.params.info;
            switch (info.phase) {
                case 'before':
                    metadata.method = info.name;
                    metadata.stack = info.stack;
                    this._waitOperations.set(info.waitId, metadata);
                    break;
                case 'log':
                    const originalMetadata = this._waitOperations.get(info.waitId);
                    originalMetadata.log.push(info.message);
                    this.onCallLog('api', info.message, sdkObject, originalMetadata);
                // Fall through.
                case 'after':
                    return;
            }
        }
        if (shouldOpenInspector(sdkObject, metadata))
            recorderSupplement_1.RecorderSupplement.getOrCreate(context, { pauseOnNextStatement: true });
        const recorder = await recorderSupplement_1.RecorderSupplement.getNoCreate(context);
        await (recorder === null || recorder === void 0 ? void 0 : recorder.onBeforeCall(sdkObject, metadata));
    }
    async onAfterCall(sdkObject, metadata) {
        var _a, _b;
        if (!sdkObject.attribution.context)
            return;
        // Process logs for waitForNavigation/waitForLoadState
        if ((_b = (_a = metadata.params) === null || _a === void 0 ? void 0 : _a.info) === null || _b === void 0 ? void 0 : _b.waitId) {
            const info = metadata.params.info;
            switch (info.phase) {
                case 'before':
                    metadata.endTime = 0;
                // Fall through.
                case 'log':
                    return;
                case 'after':
                    const originalMetadata = this._waitOperations.get(info.waitId);
                    originalMetadata.endTime = metadata.endTime;
                    originalMetadata.error = info.error;
                    this._waitOperations.delete(info.waitId);
                    metadata = originalMetadata;
                    break;
            }
        }
        const recorder = await recorderSupplement_1.RecorderSupplement.getNoCreate(sdkObject.attribution.context);
        await (recorder === null || recorder === void 0 ? void 0 : recorder.onAfterCall(metadata));
    }
    async onBeforeInputAction(sdkObject, metadata) {
        if (!sdkObject.attribution.context)
            return;
        const recorder = await recorderSupplement_1.RecorderSupplement.getNoCreate(sdkObject.attribution.context);
        await (recorder === null || recorder === void 0 ? void 0 : recorder.onBeforeInputAction(metadata));
    }
    async onCallLog(logName, message, sdkObject, metadata) {
        debugLogger_1.debugLogger.log(logName, message);
        if (!sdkObject.attribution.context)
            return;
        const recorder = await recorderSupplement_1.RecorderSupplement.getNoCreate(sdkObject.attribution.context);
        await (recorder === null || recorder === void 0 ? void 0 : recorder.updateCallLog([metadata]));
    }
}
exports.InspectorController = InspectorController;
function shouldOpenInspector(sdkObject, metadata) {
    var _a;
    if (!((_a = sdkObject.attribution.browser) === null || _a === void 0 ? void 0 : _a.options.headful) && !utils_1.isUnderTest())
        return false;
    return metadata.method === 'pause';
}
//# sourceMappingURL=inspectorController.js.map
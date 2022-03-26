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
exports.videoById = exports.actionById = exports.readTraceFile = exports.trace = void 0;
exports.trace = __importStar(require("../../trace/traceTypes"));
const kInterestingActions = ['click', 'dblclick', 'hover', 'check', 'uncheck', 'tap', 'fill', 'press', 'type', 'selectOption', 'setInputFiles', 'goto', 'setContent', 'goBack', 'goForward', 'reload'];
function readTraceFile(events, traceModel, filePath) {
    const contextEntries = new Map();
    const pageEntries = new Map();
    for (const event of events) {
        switch (event.type) {
            case 'context-created': {
                contextEntries.set(event.contextId, {
                    filePath,
                    name: event.debugName || filePath.substring(filePath.lastIndexOf('/') + 1),
                    startTime: Number.MAX_VALUE,
                    endTime: Number.MIN_VALUE,
                    created: event,
                    destroyed: undefined,
                    pages: [],
                });
                break;
            }
            case 'context-destroyed': {
                contextEntries.get(event.contextId).destroyed = event;
                break;
            }
            case 'page-created': {
                const pageEntry = {
                    created: event,
                    destroyed: undefined,
                    actions: [],
                    resources: [],
                    interestingEvents: [],
                    snapshotsByFrameId: {},
                };
                pageEntries.set(event.pageId, pageEntry);
                contextEntries.get(event.contextId).pages.push(pageEntry);
                break;
            }
            case 'page-destroyed': {
                pageEntries.get(event.pageId).destroyed = event;
                break;
            }
            case 'page-video': {
                const pageEntry = pageEntries.get(event.pageId);
                pageEntry.video = { video: event, videoId: event.contextId + '/' + event.pageId };
                break;
            }
            case 'action': {
                if (!kInterestingActions.includes(event.method))
                    break;
                const pageEntry = pageEntries.get(event.pageId);
                const actionId = event.contextId + '/' + event.pageId + '/' + pageEntry.actions.length;
                const action = {
                    actionId,
                    action: event,
                    thumbnailUrl: `/action-preview/${actionId}.png`,
                    resources: pageEntry.resources,
                };
                pageEntry.resources = [];
                pageEntry.actions.push(action);
                break;
            }
            case 'resource': {
                const pageEntry = pageEntries.get(event.pageId);
                const action = pageEntry.actions[pageEntry.actions.length - 1];
                if (action)
                    action.resources.push(event);
                else
                    pageEntry.resources.push(event);
                break;
            }
            case 'dialog-opened':
            case 'dialog-closed':
            case 'navigation':
            case 'load': {
                const pageEntry = pageEntries.get(event.pageId);
                pageEntry.interestingEvents.push(event);
                break;
            }
            case 'snapshot': {
                const pageEntry = pageEntries.get(event.pageId);
                if (!(event.frameId in pageEntry.snapshotsByFrameId))
                    pageEntry.snapshotsByFrameId[event.frameId] = [];
                pageEntry.snapshotsByFrameId[event.frameId].push(event);
                break;
            }
        }
        const contextEntry = contextEntries.get(event.contextId);
        contextEntry.startTime = Math.min(contextEntry.startTime, event.timestamp);
        contextEntry.endTime = Math.max(contextEntry.endTime, event.timestamp);
    }
    traceModel.contexts.push(...contextEntries.values());
}
exports.readTraceFile = readTraceFile;
function actionById(traceModel, actionId) {
    const [contextId, pageId, actionIndex] = actionId.split('/');
    const context = traceModel.contexts.find(entry => entry.created.contextId === contextId);
    const page = context.pages.find(entry => entry.created.pageId === pageId);
    const action = page.actions[+actionIndex];
    return { context, page, action };
}
exports.actionById = actionById;
function videoById(traceModel, videoId) {
    const [contextId, pageId] = videoId.split('/');
    const context = traceModel.contexts.find(entry => entry.created.contextId === contextId);
    const page = context.pages.find(entry => entry.created.pageId === pageId);
    return { context, page };
}
exports.videoById = videoById;
//# sourceMappingURL=traceModel.js.map
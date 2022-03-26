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
exports.captureStackTrace = exports.rewriteErrorMessage = exports.getCallerFilePath = void 0;
const path_1 = __importDefault(require("path"));
const stack_utils_1 = __importDefault(require("stack-utils"));
const utils_1 = require("./utils");
const stackUtils = new stack_utils_1.default();
function getCallerFilePath(ignorePrefix) {
    const frame = captureStackTrace().frames.find(f => !f.file.startsWith(ignorePrefix));
    return frame ? frame.file : null;
}
exports.getCallerFilePath = getCallerFilePath;
function rewriteErrorMessage(e, newMessage) {
    if (e.stack) {
        const index = e.stack.indexOf(e.message);
        if (index !== -1)
            e.stack = e.stack.substring(0, index) + newMessage + e.stack.substring(index + e.message.length);
    }
    e.message = newMessage;
    return e;
}
exports.rewriteErrorMessage = rewriteErrorMessage;
const PW_LIB_DIRS = [
    'playwright',
    'playwright-chromium',
    'playwright-firefox',
    'playwright-webkit',
].map(packageName => path_1.default.join('node_modules', packageName, 'lib'));
function captureStackTrace() {
    const stack = new Error().stack;
    const frames = [];
    for (const line of stack.split('\n')) {
        const frame = stackUtils.parseLine(line);
        if (!frame || !frame.file)
            continue;
        if (frame.file.startsWith('internal'))
            continue;
        const fileName = path_1.default.resolve(process.cwd(), frame.file);
        if (PW_LIB_DIRS.some(libDir => fileName.includes(libDir)))
            continue;
        // for tests.
        if (utils_1.isUnderTest() && fileName.includes(path_1.default.join('playwright', 'src')))
            continue;
        if (utils_1.isUnderTest() && fileName.includes(path_1.default.join('playwright', 'test', 'coverage.js')))
            continue;
        frames.push({
            file: fileName,
            line: frame.line,
            column: frame.column,
            function: frame.function,
        });
    }
    return { stack, frames };
}
exports.captureStackTrace = captureStackTrace;
//# sourceMappingURL=stackTrace.js.map
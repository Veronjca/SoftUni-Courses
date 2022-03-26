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
exports.createGuid = exports.calculateSha1 = exports.monotonicTime = exports.headersArrayToObject = exports.headersObjectToArray = exports.mkdirIfNeeded = exports.getAsBooleanFromENV = exports.getFromENV = exports.isUnderTest = exports.setUnderTest = exports.isDebugMode = exports.isError = exports.isObject = exports.isRegExp = exports.isString = exports.debugAssert = exports.assert = exports.makeWaitForNextTask = void 0;
const path_1 = __importDefault(require("path"));
const fs_1 = __importDefault(require("fs"));
const util = __importStar(require("util"));
const crypto = __importStar(require("crypto"));
const mkdirAsync = util.promisify(fs_1.default.mkdir.bind(fs_1.default));
// See https://joel.tools/microtasks/
function makeWaitForNextTask() {
    if (parseInt(process.versions.node, 10) >= 11)
        return setImmediate;
    // Unlike Node 11, Node 10 and less have a bug with Task and MicroTask execution order:
    // - https://github.com/nodejs/node/issues/22257
    //
    // So we can't simply run setImmediate to dispatch code in a following task.
    // However, we can run setImmediate from-inside setImmediate to make sure we're getting
    // in the following task.
    let spinning = false;
    const callbacks = [];
    const loop = () => {
        const callback = callbacks.shift();
        if (!callback) {
            spinning = false;
            return;
        }
        setImmediate(loop);
        // Make sure to call callback() as the last thing since it's
        // untrusted code that might throw.
        callback();
    };
    return (callback) => {
        callbacks.push(callback);
        if (!spinning) {
            spinning = true;
            setImmediate(loop);
        }
    };
}
exports.makeWaitForNextTask = makeWaitForNextTask;
function assert(value, message) {
    if (!value)
        throw new Error(message);
}
exports.assert = assert;
function debugAssert(value, message) {
    if (isUnderTest() && !value)
        throw new Error(message);
}
exports.debugAssert = debugAssert;
function isString(obj) {
    return typeof obj === 'string' || obj instanceof String;
}
exports.isString = isString;
function isRegExp(obj) {
    return obj instanceof RegExp || Object.prototype.toString.call(obj) === '[object RegExp]';
}
exports.isRegExp = isRegExp;
function isObject(obj) {
    return typeof obj === 'object' && obj !== null;
}
exports.isObject = isObject;
function isError(obj) {
    return obj instanceof Error || (obj && obj.__proto__ && obj.__proto__.name === 'Error');
}
exports.isError = isError;
const isInDebugMode = !!getFromENV('PWDEBUG');
function isDebugMode() {
    return isInDebugMode;
}
exports.isDebugMode = isDebugMode;
let _isUnderTest = false;
function setUnderTest() {
    _isUnderTest = true;
}
exports.setUnderTest = setUnderTest;
function isUnderTest() {
    return _isUnderTest;
}
exports.isUnderTest = isUnderTest;
function getFromENV(name) {
    let value = process.env[name];
    value = value === undefined ? process.env[`npm_config_${name.toLowerCase()}`] : value;
    value = value === undefined ? process.env[`npm_package_config_${name.toLowerCase()}`] : value;
    return value;
}
exports.getFromENV = getFromENV;
function getAsBooleanFromENV(name) {
    const value = getFromENV(name);
    return !!value && value !== 'false' && value !== '0';
}
exports.getAsBooleanFromENV = getAsBooleanFromENV;
async function mkdirIfNeeded(filePath) {
    // This will harmlessly throw on windows if the dirname is the root directory.
    await mkdirAsync(path_1.default.dirname(filePath), { recursive: true }).catch(() => { });
}
exports.mkdirIfNeeded = mkdirIfNeeded;
function headersObjectToArray(headers) {
    const result = [];
    for (const name in headers) {
        if (!Object.is(headers[name], undefined))
            result.push({ name, value: headers[name] });
    }
    return result;
}
exports.headersObjectToArray = headersObjectToArray;
function headersArrayToObject(headers, lowerCase) {
    const result = {};
    for (const { name, value } of headers)
        result[lowerCase ? name.toLowerCase() : name] = value;
    return result;
}
exports.headersArrayToObject = headersArrayToObject;
function monotonicTime() {
    const [seconds, nanoseconds] = process.hrtime();
    return seconds * 1000 + (nanoseconds / 1000 | 0) / 1000;
}
exports.monotonicTime = monotonicTime;
function calculateSha1(buffer) {
    const hash = crypto.createHash('sha1');
    hash.update(buffer);
    return hash.digest('hex');
}
exports.calculateSha1 = calculateSha1;
function createGuid() {
    return crypto.randomBytes(16).toString('hex');
}
exports.createGuid = createGuid;
//# sourceMappingURL=utils.js.map
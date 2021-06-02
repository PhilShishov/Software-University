"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class Requester {
    constructor(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = 'undefined';
        this.fulfilled = false;
    }
}
exports.default = Requester;
//# sourceMappingURL=httpRequest.js.map
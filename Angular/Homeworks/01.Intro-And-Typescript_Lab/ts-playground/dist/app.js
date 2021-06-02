"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const httpRequest_1 = __importDefault(require("./httpRequest"));
const data = new httpRequest_1.default("GET", "http://google.com", "HTTP/1.1", "");
console.log(data);
//# sourceMappingURL=app.js.map
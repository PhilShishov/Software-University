import Requester from "./httpRequest";

const data = new Requester(
  "GET",
  "http://google.com",
  "HTTP/1.1",
  "",
);

console.log(data);
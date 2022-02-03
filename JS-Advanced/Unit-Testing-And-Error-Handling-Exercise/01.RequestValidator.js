function validator(request) {
  let props = ["method", "uri", "version", "message"];
  let methods = ["GET", "POST", "DELETE", "CONNECT"];
  let versions = ["HTTP/0.9", "HTTP/1.0", "HTTP/1.1", "HTTP/2.0"];

  for (let i = 0; i < props.length; i++) {
    if (!request.hasOwnProperty(props[i])) {
      let invalid = props[i][0].toUpperCase() + props[i].slice(1);
      if (invalid === "Uri") {
        invalid = "URI";
      }
      throw new Error(`Invalid request header: Invalid ${invalid}`);
    } else if (!methods.includes(request["method"])) {
      throw new Error("Invalid request header: Invalid Method");
    }
  }

  let uriRegEx = /^[A-za-z0-9\*\.]+$/g;
  if (!uriRegEx.test(request["uri"])) {
    throw new Error("Invalid request header: Invalid URI");
  }

  if (!versions.includes(request["version"])) {
    throw new Error("Invalid request header: Invalid Version");
  }
  let messageRegEx = /^[^<>\&'"\r\n\\]*$/g;
  if (!messageRegEx.test(request["message"])) {
    throw new Error("Invalid request header: Invalid Message");
  }

  return request;
}

console.log(
  validator({
    method: "GET",
    uri: "svn.public.catalog",
    version: "HTTP/1.1",
    message: "'; DROP TABLE'",
  })
);

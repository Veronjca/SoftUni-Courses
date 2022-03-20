async function request(method, url, data) {
    let options = {
      method,
      headers: {},
    };
  
    if (data) {
      options.body = JSON.stringify(data);
      options.headers["Content-Type"] = "application/json";
    }
   
    if (sessionStorage.user) {
      let user = JSON.parse(sessionStorage.user);
      options.headers["X-authorization"] = user.accessToken;
    }
  
    try {
      let response = await fetch(url, options);
  
      if (response.ok !== true) {
        const error = await response.json();
        throw new Error(error.message);
      }
  
      if (response.status === 204) {
        return response;
      } else if (response.status === 403) {
        sessionStorage.clear();
      } else {
        return response.json();
      }
    } catch (error) {
      alert(error.message);
    }
  }
  
  const get = request.bind(null, "GET");
  const post = request.bind(null, "POST");
  const put = request.bind(null, "PUT");
  const del = request.bind(null, "DELETE");
  
  export { get, post, put, del as delete };
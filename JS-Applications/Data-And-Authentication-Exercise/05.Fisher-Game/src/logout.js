let baseURL = "http://localhost:3030/users/logout";
async function solve() {
  let authToken = JSON.parse(sessionStorage.user).accessToken;

  let response = await fetch(baseURL, {
    method: "GET",
    headers: {
      "X-Authorization": authToken,
    },
  });

  if(response.ok){
    sessionStorage.clear();
    location.href = "./index.html";
  }
}

export let logout = solve;

async function solve() {
  let authToken = JSON.parse(sessionStorage.user).accessToken;
  let baseURL = "http://localhost:3030/users/";

  let response = await fetch(`${baseURL}logout`, {
    method: "GET",
    headers: {
      "X-Authorization": authToken,
    },
  });

  if (response.ok) {
    sessionStorage.clear();
    location.href = "./home.html";
  }
}

export let logout = solve;

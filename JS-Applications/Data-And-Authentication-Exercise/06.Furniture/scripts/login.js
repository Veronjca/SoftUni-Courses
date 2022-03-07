async function solve(loginForm, baseURL) {
  let formData = new FormData(loginForm);
  let email = formData.get("email");
  let password = formData.get("password");

  let response = await fetch(`${baseURL}login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ email, password }),
  });

  let user = await response.json();
  sessionStorage.setItem("user", JSON.stringify(user));
  loginForm.reset();

  if (!sessionStorage.user) {
    alert("Failed to Login!");
  } else {
    location.href = "./homeLogged.html";
  }
}

export const login = solve;

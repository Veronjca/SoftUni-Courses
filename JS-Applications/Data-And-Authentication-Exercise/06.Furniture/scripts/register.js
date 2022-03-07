async function solve(registerForm, baseURL) {
  let formData = new FormData(registerForm);
  let email = formData.get("email");
  let password = formData.get("password");
  let rePass = formData.get("rePass");

  if (password !== rePass) {
    alert("Passwords dont't match!");
    registerForm.reset();
    return;
  }

  let response = await fetch(`${baseURL}register`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ email, password }),
  });

  let responseBody = await response.json();

  if (!response.ok) {
    alert("Invalid email!");
  } else {
    sessionStorage.setItem("user", JSON.stringify(responseBody));
    location.href = "./homeLogged.html";
  }
  registerForm.reset();
}

export const register = solve;
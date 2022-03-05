const form = document.querySelector("form");
const baseURL = "http://localhost:3030/users/login";

let span = document.querySelector("span");
let loginElement = document.querySelector("#login");
let navigationElement = document.querySelector("nav");
let logoutElement = document.querySelector("#logout");
logoutElement.style.display = "none";

window.onload = () => {
  let ankerElements = navigationElement.querySelectorAll("a");
  ankerElements.forEach((x) => {
    x.classList.remove("active");
  });

  if (sessionStorage.user) {
    let currentUser = JSON.parse(sessionStorage.user);
    span.textContent = currentUser.username ? currentUser.user : "guest";
  }

  loginElement.classList.add('active');
}

form.addEventListener("submit", async (ev) => {
  ev.preventDefault();

  let formData = new FormData(form);
  let email = formData.get("email");
  let password = formData.get("password");

  let response = await fetch(baseURL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ email, password }),
  });

  let user = await response.json();
  sessionStorage.setItem("user", JSON.stringify(user));
  form.reset();

  if (!sessionStorage.user) {
    alert("Failed to Login!");
  } else {
    location.href = "./index.html";
  }
});

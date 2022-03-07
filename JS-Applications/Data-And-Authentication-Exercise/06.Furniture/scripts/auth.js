import { register } from "./register.js";
import { login } from "./login.js";

let loginForm = document.querySelector("#login-form");
let registerForm = document.querySelector("#register-form");
let baseURL = "http://localhost:3030/users/";

function solve() {
  registerForm.addEventListener("submit", (ev) => {
    ev.preventDefault();
    register(registerForm, baseURL);
  });

  loginForm.addEventListener("submit", (ev) => {
    ev.preventDefault();
    login(loginForm, baseURL);
  });
}

window.onload = solve;

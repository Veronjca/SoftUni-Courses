import * as actions from "./actions.js";
import { logout } from "./auth.js";

//There is bug that I can't fix. 
//The app refresh when trying to access home page from movie details page. 
//Let me know if you solve it!
actions.showHomePage();

let anchorElements = Array.from(document.querySelectorAll("nav a"));

let loginElement = anchorElements.find((x) => x.textContent === "Login");
loginElement.addEventListener("click", (ev) => {
  ev.preventDefault();
  actions.showLoginPage();
});

let registerElement = anchorElements.find((x) => x.textContent === "Register");
registerElement.addEventListener("click", (ev) => {
  ev.preventDefault();
  actions.showRegisterPage();
});

let logoutElement = anchorElements.find((x) => x.textContent === "Logout");
logoutElement.addEventListener("click", async (ev) => {
  ev.preventDefault();
  let response = await logout();

  if (response.status === 204) {
    sessionStorage.clear();
    actions.showLoginPage();
  }
});

let movieElement = anchorElements.find((x) => x.textContent === "Movies");
movieElement.addEventListener("click", (ev) => {
  ev.preventDefault();
  actions.showHomePage();
});

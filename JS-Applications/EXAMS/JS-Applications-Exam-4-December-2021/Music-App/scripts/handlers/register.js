import { registerUser } from "./musicAppService.js";
import page from "../../node_modules/page/page.mjs";

export async function registerHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.target);
  let email = formData.get("email").trim();
  let password = formData.get("password").trim();
  let repass = formData.get("conf-pass").trim();

  if (!email || !password) {
    alert("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  } else if (password !== repass) {
    alert("Passwords don't match!");
    ev.currentTarget.reset();
    return;
  }

  let user = await registerUser(email, password);
  if (user) {
    sessionStorage.setItem("user", JSON.stringify(user));
    page.redirect("/");
  }
}

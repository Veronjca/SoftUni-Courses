import { registerUser } from "./memeService.js";
import page from "../../node_modules/page/page.mjs";
import { notificationView } from "../views/notification.js";

export async function registerHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.target);
  let username = formData.get("username").trim();
  let email = formData.get("email").trim();
  let password = formData.get("password").trim();
  let repass = formData.get("repeatPass").trim();
  let gender = formData.get("gender").trim();

  if (!email || !password || !username || !gender) {
    notificationView("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  } else if (password !== repass) {
    notificationView("Passwords don't match!");
    ev.currentTarget.reset();
    return;
  }

  let user = await registerUser(username, email, password, gender);
  if (user) {
    sessionStorage.setItem("user", JSON.stringify(user));
    page.redirect("/all");
  }
}

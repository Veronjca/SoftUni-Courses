import { loginUser } from "./memeService.js";
import page from "../../node_modules/page/page.mjs";
import { notificationView } from "../views/notification.js";

export async function loginHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let email = formData.get("email").trim();
  let password = formData.get("password").trim();

  if (!email || !password) {
    notificationView("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  }

  let user = await loginUser(email, password);
  if (user) {
    sessionStorage.setItem("user", JSON.stringify(user));
    page.redirect("/all");
  }
}

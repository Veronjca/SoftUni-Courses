import { loginUser } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function loginHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let email = formData.get("email");
  let password = formData.get("password");

  if (!email || !password) {
    alert("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  }

  let user = await loginUser(email, password);
  if (user) {
    sessionStorage.setItem("user", JSON.stringify(user));
    page.redirect("/dashboard");
  }
}

import { registerUser } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function registerHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let email = formData.get("email");
  let password = formData.get("password");
  let repass = formData.get("confirm-pass");

  if (!email || !password || !repass) {
    alert("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  } else if (password !== repass) {
    alert("Passwords dont't match.");
    ev.currentTarget.reset();
    return;
  }

  let user = await registerUser(email, password);
  if (user) {
    sessionStorage.setItem("user", JSON.stringify(user));
    page.redirect("/dashboard");
  }
}

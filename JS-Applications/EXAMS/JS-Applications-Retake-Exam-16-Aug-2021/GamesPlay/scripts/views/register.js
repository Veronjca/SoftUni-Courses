import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { registerHandler } from "../handlers/register.js";

const mainElement = document.querySelector("#main-content");

const registerTemplate = () => html`<section id="register-page" class="content auth">
  <form @submit=${registerHandler} id="register">
    <div class="container">
      <div class="brand-logo"></div>
      <h1>Register</h1>

      <label for="email">Email:</label>
      <input type="email" id="email" name="email" placeholder="maria@email.com" />

      <label for="pass">Password:</label>
      <input type="password" name="password" id="register-password" />

      <label for="con-pass">Confirm Password:</label>
      <input type="password" name="confirm-password" id="confirm-password" />

      <input class="btn submit" type="submit" value="Register" />

      <p class="field">
        <span>If you already have profile click <a href="/login">here</a></span>
      </p>
    </div>
  </form>
</section>`;

export const registerView = () => {
  render(registerTemplate(), mainElement);
};

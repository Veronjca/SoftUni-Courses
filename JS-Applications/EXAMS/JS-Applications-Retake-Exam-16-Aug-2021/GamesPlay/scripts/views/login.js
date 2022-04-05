import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { loginHandler } from "../handlers/login.js";

const mainElement = document.querySelector("#main-content");

const loginTemplate = () => html` <section id="login-page" class="auth">
  <form @submit=${loginHandler} id="login">
    <div class="container">
      <div class="brand-logo"></div>
      <h1>Login</h1>
      <label for="email">Email:</label>
      <input type="email" id="email" name="email" placeholder="Sokka@gmail.com" />

      <label for="login-pass">Password:</label>
      <input type="password" id="login-password" name="password" />
      <input type="submit" class="btn submit" value="Login" />
      <p class="field">
        <span>If you don't have profile click <a href="/register">here</a></span>
      </p>
    </div>
  </form>
</section>`;

export const loginView = () => {
  render(loginTemplate(), mainElement);
};

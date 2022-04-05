import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { loginHandler } from "../handlers/login.js";

const mainContainer = document.getElementById("main-content");

const loginTemplate = () => html`<section id="loginPage">
  <form @submit=${loginHandler}>
    <fieldset>
      <legend>Login</legend>

      <label for="email" class="vhide">Email</label>
      <input id="email" class="email" name="email" type="text" placeholder="Email" />

      <label for="password" class="vhide">Password</label>
      <input id="password" class="password" name="password" type="password" placeholder="Password" />

      <button type="submit" class="login">Login</button>

      <p class="field">
        <span>If you don't have profile click <a href="/register">here</a></span>
      </p>
    </fieldset>
  </form>
</section>`;

export const loginView = () => {
  render(loginTemplate(), mainContainer);
};

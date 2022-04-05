import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { loginHandler } from "../handlers/login.js";

const mainContainer = document.getElementById("content");

const loginTemplate = () => html`<section id="loginaPage">
  <form @submit=${loginHandler} class="loginForm">
    <h2>Login</h2>
    <div>
      <label for="email">Email:</label>
      <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="" />
    </div>
    <div>
      <label for="password">Password:</label>
      <input id="password" name="password" type="password" placeholder="********" value="" />
    </div>

    <button class="btn" type="submit">Login</button>

    <p class="field">
      <span>If you don't have profile click <a href="/register">here</a></span>
    </p>
  </form>
</section>`;

export const loginView = () => {
  render(loginTemplate(), mainContainer);
};

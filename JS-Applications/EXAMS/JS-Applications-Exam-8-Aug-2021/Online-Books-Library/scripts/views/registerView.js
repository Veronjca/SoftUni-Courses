import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { registerHandler } from "../handlers/registerHandler.js";

const mainElement = document.querySelector("#site-content");

const registerTemplate = () => html`<section id="register-page" class="register">
  <form @submit="${registerHandler}" id="register-form" action="" method="">
    <fieldset>
      <legend>Register Form</legend>
      <p class="field">
        <label for="email">Email</label>
        <span class="input">
          <input type="text" name="email" id="email" placeholder="Email" />
        </span>
      </p>
      <p class="field">
        <label for="password">Password</label>
        <span class="input">
          <input type="password" name="password" id="password" placeholder="Password" />
        </span>
      </p>
      <p class="field">
        <label for="repeat-pass">Repeat Password</label>
        <span class="input">
          <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password" />
        </span>
      </p>
      <input class="button submit" type="submit" value="Register" />
    </fieldset>
  </form>
</section>`;

export const registerView = () => {
  render(registerTemplate(), mainElement);
};

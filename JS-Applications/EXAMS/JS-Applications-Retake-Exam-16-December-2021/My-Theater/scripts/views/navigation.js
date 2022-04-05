import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { logoutHandler } from "../handlers/logout.js";

const navContainer = document.querySelector("header");

const navigationTemplate = () => html` <nav>
  <a href="/">Theater</a>
  <ul>
    ${sessionStorage.user
      ? html`<li><a href="/profile">Profile</a></li>
          <li><a href="/create">Create Event</a></li>
          <li><a @click=${logoutHandler} href="">Logout</a></li>`
      : html`<li><a href="/login">Login</a></li>
          <li><a href="/register">Register</a></li>`}
  </ul>
</nav>`;

export const navigationView = (ctx, next) => {
  render(navigationTemplate(), navContainer);
  next();
};

import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { logoutHandler } from "../handlers/logout.js";

const navContainer = document.querySelector("header");

const navigationTemplate = () => html` <nav>
  <img src="./images/headphones.png" />
  <a href="/">Home</a>
  <ul>
    <li><a href="/catalog">Catalog</a></li>
    <li><a href="/search">Search</a></li>
    ${sessionStorage.user
      ? html` <li><a href="/create">Create Album</a></li>
          <li><a @click=${logoutHandler} href="javascript:void(0)">Logout</a></li>`
      : html` <li><a href="/login">Login</a></li>
          <li><a href="/register">Register</a></li>`}
  </ul>
</nav>`;

export const navigationView = (ctx, next) => {
  render(navigationTemplate(), navContainer);
  next();
};

import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { logoutHandler } from "../handlers/logout.js";

const navbarContainer = document.querySelector("header");

const navbarTemplate = () => html` <h1><a class="home" href="/">GamesPlay</a></h1>
  <nav>
    <a href="/catalogue">All games</a>
    ${sessionStorage.user
      ? html`<div id="user">
          <a href="/create">Create Game</a>
          <a @click=${logoutHandler} href="javascript:void(0)">Logout</a>
        </div>`
      : html`<div id="guest">
          <a href="/login">Login</a>
          <a href="/register">Register</a>
        </div>`}
  </nav>`;

export const navbarView = (ctx, next) => {
  render(navbarTemplate(), navbarContainer);
  next();
};

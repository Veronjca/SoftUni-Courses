import { render, html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { logoutHandler } from "../handlers/logoutHandler.js";

const navContainer = document.querySelector("#site-header");

const navTemplate = () => html` <nav class="navbar">
  <section class="navbar-dashboard">
    <a href="/dashboard">Dashboard</a>
    ${sessionStorage.user
      ? html` <div id="user">
          <span>Welcome, ${sessionStorage.user ? JSON.parse(sessionStorage.user).email : nothing }</span>
          <a class="button" href="/MyBooks">My Books</a>
          <a class="button" href="/addBook">Add Book</a>
          <a @click=${logoutHandler} class="button" href="javascript:void(0)">Logout</a>
        </div>`
      : html` <div id="guest">
          <a class="button" href="/login">Login</a>
          <a class="button" href="/register">Register</a>
        </div>`}
  </section>
</nav>`;

export const nagivationView = (ctx, next) => {
  render(navTemplate(), navContainer);
  next();
};

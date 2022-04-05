import {render, html} from "../../node_modules/lit-html/lit-html.js";
import { logoutHandler } from "../handlers/logout.js";

const navContainer = document.getElementsByTagName("nav")[0];

const navigationTemplate = (email) => html`
  ${sessionStorage.user
    ? html`<div class="user">
        <a href="/all">All Memes</a>
        <a href="/create">Create Meme</a>
        <div class="profile">
          <span>Welcome, ${email}</span>
          <a href="/profile">My Profile</a>
          <a @click=${logoutHandler} href="javascript:void(0)">Logout</a>
        </div>
      </div>`
    : html`<div class="guest">
        <a class="active" href="/">Home Page</a>
        <a href="/all">All Memes</a>
        <div class="profile">
          <a href="/login">Login</a>
          <a href="/register">Register</a>
        </div>
      </div>`}
`;

export const navigationView = (ctx, next) => {
  let email = "";
  if (sessionStorage.user) {
    email = JSON.parse(sessionStorage.user).email;
  }

  render(navigationTemplate(email), navContainer);
  next();
};

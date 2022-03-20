import { render, html } from "../../node_modules/lit-html/lit-html.js";
import page from "../../node_modules/page/page.mjs";
import { navBarView } from "./navBarView.js";
import * as requestHandler from "../requestHandler.js";

const container = document.querySelector("#mainContainer");

const registerHandler = async (ev) => {
  ev.preventDefault();
  let formData = new FormData(ev.target);
  let email = formData.get("email");
  let password = formData.get("password");
  let repeatedPassword = formData.get("repeatPassword");

  if (password !== repeatedPassword) {
    alert("Passwords don't match!");
    ev.target.reset();
    return;
  } else if (password.length < 3) {
    alert("Password should be at least 3 characters long!");
    ev.target.reset();
    return;
  }
  let digitMatches = email.match(/\d+/g);
  let specialChars = email.match(/[!@#\$%\^\&*\)\(+=._\-\]]+/g);

  if (!digitMatches || !specialChars) {
    alert("Invalid email!");
    ev.target.reset();
    return;
  }

  let user = await requestHandler.registerUser(email, password);
  if (user) {
    sessionStorage.setItem("user", JSON.stringify(user));
    page.redirect("/home");
  }
  ev.target.reset();
};

const registerTemplate = () => html`<div class="container home wrapper  my-md-5 pl-md-5">
  <div class="row-form d-md-flex flex-mb-equal ">
    <div class="col-md-4">
      <img class="responsive" src="./images/idea.png" alt="" />
    </div>
    <form @submit=${registerHandler} class="form-user col-md-7" action="" method="">
      <div class="text-center mb-4">
        <h1 class="h3 mb-3 font-weight-normal">Register</h1>
      </div>
      <div class="form-label-group">
        <label for="email">Email</label>
        <input type="text" id="email" name="email" class="form-control" placeholder="Email" required="" autofocus="" />
      </div>
      <div class="form-label-group">
        <label for="password">Password</label>
        <input type="password" id="password" name="password" class="form-control" placeholder="Password" required="" />
      </div>
      <div class="form-label-group">
        <label for="inputRepeatPassword">Repeat Password</label>
        <input
          type="password"
          id="inputRepeatPassword"
          name="repeatPassword"
          class="form-control"
          placeholder="Repeat Password"
          required=""
        />
      </div>
      <button class="btn btn-lg btn-dark btn-block" type="submit">Sign Up</button>
      <div class="text-center mb-4">
        <p class="alreadyUser">Don't have account? Then just <a href="">Sign-In</a>!</p>
      </div>
      <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2019.</p>
    </form>
  </div>
</div>`;

export const registerView = (ctx) => {
  navBarView();
  render(registerTemplate(), container);
};

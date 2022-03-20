import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { navBarView } from "./navBarView.js";
import * as requestHandler from "../requestHandler.js";
import page from "../../node_modules/page/page.mjs";

const container = document.querySelector("#mainContainer");

async function createIdea(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.target);
  let title = formData.get("title");
  let description = formData.get("description");
  let img = formData.get("imageURL");

  if (title.length < 6) {
    alert("Title must be at least six characters long!");
    ev.target.reset();
    return;
  } else if (description.length < 10) {
    alert("Description must be at least ten characters long!");
    ev.target.reset();
    return;
  } else if (img.length < 5) {
    alert("Invalid image URL!");
    ev.target.reset();
    return;
  }
  let idea = await requestHandler.createNewIdea(title, description, img);
  if (idea) {
    page.redirect("/dashboard");
    ev.target.reset();
  }
}

const createTemplate = () => html` <div class="container home wrapper  my-md-5 pl-md-5">
  <div class=" d-md-flex flex-mb-equal ">
    <div class="col-md-6">
      <img class="responsive-ideas create" src="./images/creativity_painted_face.jpg" alt="" />
    </div>
    <form @submit=${createIdea} class="form-idea col-md-5" action="#/create" method="post">
      <div class="text-center mb-4">
        <h1 class="h3 mb-3 font-weight-normal">Share Your Idea</h1>
      </div>
      <div class="form-label-group">
        <label for="ideaTitle">Title</label>
        <input type="text" id="ideaTitle" name="title" class="form-control" placeholder="What is your idea?" required="" autofocus="" />
      </div>
      <div class="form-label-group">
        <label for="ideaDescription">Description</label>
        <textarea type="text" name="description" class="form-control" placeholder="Description" required=""></textarea>
      </div>
      <div class="form-label-group">
        <label for="inputURL">Add Image</label>
        <input type="text" id="inputURL" name="imageURL" class="form-control" placeholder="Image URL" required="" />
      </div>
      <button class="btn btn-lg btn-dark btn-block" type="submit">Create</button>
      <p class="mt-5 mb-3 text-muted text-center">© SoftTerest - 2021.</p>
    </form>
  </div>
</div>`;

export const createView = (ctx) => {
  navBarView();
  render(createTemplate(), container);
};

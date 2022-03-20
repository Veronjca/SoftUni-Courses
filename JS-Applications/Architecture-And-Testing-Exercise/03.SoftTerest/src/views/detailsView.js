import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { navBarView } from "./navBarView.js";
import * as requestHandler from "../requestHandler.js";
import page from "../../node_modules/page/page.mjs";

const container = document.querySelector("#mainContainer");

async function deleteIdea(ev) {
  let result = await requestHandler.deleteIdea(ev.target.id);
  if (result) {
    page.redirect("/dashboard");
  }
}

const detailsTemplate = (idea, isCreator) => html` <div class="container home some">
  <img class="det-img" src="./.${idea.img}" />
  <div class="desc">
    <h2 class="display-5">${idea.title}</h2>
    <p class="infoType">Description:</p>
    <p class="idea-description">${idea.description}</p>
  </div>
  <div class="text-center">
    <a id=${idea._id} @click=${deleteIdea} class="btn detb" style="display: ${isCreator ? "inline" : "none"};" href="javascript:void(0)">Delete</a>
  </div>
</div>`;

export const detailsView = async (ctx) => {
  let idea = await requestHandler.getIdeaDetails(ctx.params.ideaId);
  let isCreator = false;
  let user;
  if (sessionStorage.user) {
    user = JSON.parse(sessionStorage.user);
    isCreator = user._id === idea._ownerId ? true : false;
  }
  if (idea) {
    navBarView();
    render(detailsTemplate(idea, isCreator), container);
  }
};

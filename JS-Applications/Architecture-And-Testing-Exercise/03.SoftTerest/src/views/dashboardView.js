import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { navBarView } from "./navBarView.js";
import * as requestHandler from "../requestHandler.js";

const container = document.querySelector("#mainContainer");

const dashboardTemplate = (ideas) =>
  html`<div id="dashboard-holder">
    ${ideas.length > 0
      ? ideas.map(
          (idea) => html`<div class="card overflow-hidden current-card details" style="width: 20rem; height: 18rem;">
            <div class="card-body">
              <p class="card-text">${idea.title}</p>
            </div>
            <img class="card-image" src=${idea.img} alt=${idea.title} />
            <a id=${idea._id} class="btn" href="/ideas/${idea._id}">Details</a>
          </div>`
        )
      : html`<h1>No ideas yet! Be the first one :)</h1>`}
  </div>`;

export const dashboardView = async (ctx) => {
  let ideas = await requestHandler.getAllIdeas();
  navBarView();
  render(dashboardTemplate(ideas), container);
};

import { html, nothing, render } from "../../node_modules/lit-html/lit-html.js";
import { getMeme } from "../handlers/memeService.js";
import { deleteMemeHandler } from "../handlers/deleteMeme.js";

const mainContainer = document.getElementsByTagName("main")[0];

const memeDetailsTemplate = (meme, isOwner) => html`<section id="meme-details">
  <h1>Meme Title: ${meme.title}</h1>
  <div class="meme-details">
    <div class="meme-img">
      <img alt="meme-alt" src=${meme.imageUrl} />
    </div>
    <div class="meme-description">
      <h2>Meme Description</h2>
      <p>${meme.description}</p>

      ${isOwner
        ? html` <a class="button warning" href="/edit/${meme._id}">Edit</a>
            <button id=${meme._id} @click=${deleteMemeHandler} class="button danger">Delete</button>`
        : nothing}
    </div>
  </div>
</section>`;

export const memeDetailsView = async (ctx) => {
  let isOwner = false;
  let meme = await getMeme(ctx.params.memeId);

  if (sessionStorage.user) {
    let user = JSON.parse(sessionStorage.user);
    isOwner = meme._ownerId === user._id;
  }
  render(memeDetailsTemplate(meme, isOwner), mainContainer);
};

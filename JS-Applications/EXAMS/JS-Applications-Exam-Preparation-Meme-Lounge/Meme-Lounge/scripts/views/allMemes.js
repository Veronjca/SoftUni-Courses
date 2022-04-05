import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getAllMemes } from "../handlers/memeService.js";

const mainContainer = document.getElementsByTagName("main")[0];

const allMemesTemplae = (memes) => html` <section id="meme-feed">
  <h1>All Memes</h1>
  <div id="memes">
    ${memes.length
      ? html`${memes.map(
          (m) => html`<div class="meme">
            <div class="card">
              <div class="info">
                <p class="meme-title">${m.title}</p>
                <img class="meme-image" alt="meme-img" src=${m.imageUrl} />
              </div>
              <div id="data-buttons">
                <a class="button" href="/memes/${m._id}">Details</a>
              </div>
            </div>
          </div>`
        )}`
      : html` <p class="no-memes">No memes in database.</p>`}
  </div>
</section>`;

export const allMemesView = async () => {
  let memes = await getAllMemes();

  render(allMemesTemplae(memes), mainContainer);
};

import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { getAllGames } from "../handlers/requestHandler.js";

const mainElement = document.querySelector("#main-content");

const catalogueTemplate = (games) => html`<section id="catalog-page">
  <h1>All Games</h1>
  ${games.length > 0 ? html`${games.map(game => html` <div class="allGames">
    <div class="allGames-info">
      <img src=${game.imageUrl} />
      <h6>${game.category}</h6>
      <h2>${game.title}</h2>
      <a href="/games/${game._id}" class="details-button">Details</a>
    </div>
  </div>`)}` : html`  <h3 class="no-articles">No articles yet</h3>`}
</section>`;

export const catalogueView = async () => {
let games = await getAllGames();
  render(catalogueTemplate(games), mainElement);
};

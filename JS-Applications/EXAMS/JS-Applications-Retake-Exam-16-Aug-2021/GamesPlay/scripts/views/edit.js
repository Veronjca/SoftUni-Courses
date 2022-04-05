import { render, html } from "../../node_modules/lit-html/lit-html.js";
import { editHandler } from "../handlers/editGame.js";
import { getOneGame } from "../handlers/requestHandler.js";

const mainElement = document.querySelector("#main-content");

const editTemplate = (book) => html`<section id="edit-page" class="auth">
  <form @submit=${editHandler} id="edit">
    <div class="container">
      <h1>Edit Game</h1>
      <label for="leg-title">Legendary title:</label>
      <input type="text" id="title" name="title" .value=${book.title} />

      <label for="category">Category:</label>
      <input type="text" id="category" name="category" .value=${book.category} />

      <label for="levels">MaxLevel:</label>
      <input type="number" id="maxLevel" name="maxLevel" min="1" .value=${book.maxLevel} />

      <label for="game-img">Image:</label>
      <input type="text" id="imageUrl" name="imageUrl" .value=${book.imageUrl} />

      <label for="summary">Summary:</label>
      <textarea name="summary" id="summary" .value=${book.summary}></textarea>
      <input class="btn submit" type="submit" value="Edit Game" />
    </div>
  </form>
</section>`;

export const editView = async (ctx) => {
  let book = await getOneGame(ctx.params.gameId);
  render(editTemplate(book), mainElement);
};

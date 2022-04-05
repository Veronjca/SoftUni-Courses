import { render, html, nothing } from "../../node_modules/lit-html/lit-html.js";
import { createCommentHandler } from "../handlers/createComment.js";
import { deleteGameHandler } from "../handlers/deleteGame.js";
import { getAllCommentsForSpecificGame, getOneGame } from "../handlers/requestHandler.js";

const mainElement = document.querySelector("#main-content");

const detailsTemplate = (game, comments, isOwner) => html`<section id="game-details">
  <h1>Game Details</h1>
  <div class="info-section">
    <div class="game-header">
      <img class="game-img" src=${game.imageUrl} />
      <h1>${game.title}</h1>
      <span class="levels">MaxLevel: ${game.maxLevel}</span>
      <p class="type">${game.category}</p>
    </div>
    <p class="text">${game.summary}</p>

    <!-- Bonus ( for Guests and Users ) -->
    <div class="details-comments">
      <h2>Comments:</h2>
      <ul>
        ${comments.length > 0
          ? html`${comments.map(
              (c) => html`<li class="comment">
                <p>Content: ${c.comment}</p>
              </li>`
            )}`
          : html`<p class="no-comment">No comments.</p>`}
      </ul>
    </div>
    <!-- Edit/Delete buttons ( Only for creator of this game )  -->
    <div class="buttons">
      ${isOwner
        ? html` <a href="/edit/${game._id}" class="button">Edit</a>
            <a id=${game._id} @click=${deleteGameHandler} href="javascript:void(0)" class="button">Delete</a>`
        : nothing}
    </div>
  </div>
  <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
  ${sessionStorage.user && !isOwner
    ? html` <article class="create-comment">
    <label>Add new comment:</label>
    <form @submit=${createCommentHandler} id=${game._id} class="form">
      <textarea name="comment" placeholder="Comment......"></textarea>
      <input class="btn submit" type="submit" value="Add Comment" />
    </form>
  </article>
</section>`
    : nothing}
</section> `;

export const detailsView = async (ctx) => {
  let isOwner = false;
  let gameId = ctx.params.gameId;
  let game = await getOneGame(gameId);
  let comments = await getAllCommentsForSpecificGame(gameId);

  if (sessionStorage.user) {
    let user = JSON.parse(sessionStorage.user);
    isOwner = game._ownerId === user._id;
  }

  render(detailsTemplate(game, comments, isOwner), mainElement);
};

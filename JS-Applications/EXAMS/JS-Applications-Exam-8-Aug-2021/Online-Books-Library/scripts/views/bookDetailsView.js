import { html, nothing, render } from "../../node_modules/lit-html/lit-html.js";
import { getBookDetails, deleteBook, getLikesFromSpecificUser, getAllLikes, likeABook } from "../handlers/requestHandler.js";
import page from "../../node_modules/page/page.mjs";

const mainElement = document.querySelector("#site-content");

async function likeBook(ev) {
  await likeABook(ev.currentTarget.id);
}

async function deleteCurrentBook(ev) {
  let bookId = ev.currentTarget.id;

  if (confirm("Are you sure you want to delete this book?")) {
    let deleted = await deleteBook(bookId);
    if (deleted) {
      page.redirect("/");
    }
  }
}

const bookDetailsTemplate = (book, isOwner, isLiked, likes) => html`<section id="details-page" class="details">
  <div class="book-information">
    <h3>${book.title}</h3>
    <p class="type">Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl} /></p>
    <div class="actions">
      ${isOwner
        ? html` <a class="button" href="/edit/${book._id}">Edit</a>
            <a id=${book._id} @click=${deleteCurrentBook} class="button" href="javascript:void(0)">Delete</a>`
        : nothing}
      ${sessionStorage.user && !isOwner && !isLiked ? html`<a @click=${likeBook} id=${book._id} class="button" href="">Like</a>` : nothing}
      <div class="likes">
        <img class="hearts" src="/images/heart.png" />
        <span id="total-likes">Likes: ${likes}</span>
      </div>
    </div>
  </div>
  <div class="book-description">
    <h3>Description:</h3>
    <p>${book.description}</p>
  </div>
</section>`;

export const bookDetailsView = async (ctx) => {
  let isOwner = false;
  let isLiked = false;
  let book = await getBookDetails(ctx.params.bookId);
  if (sessionStorage.user) {
    let user = JSON.parse(sessionStorage.user);
    isOwner = user._id === book._ownerId;
    isLiked = (await getLikesFromSpecificUser(book._id, user._id)) > 0;
  }

  let likes = await getAllLikes(book._id);
  render(bookDetailsTemplate(book, isOwner, isLiked, likes), mainElement);
};

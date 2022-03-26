import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getAllBooks } from "../handlers/requestHandler.js";

const mainElement = document.querySelector("#site-content");

const dashboardTemplate = (books) => html`<section id="dashboard-page" class="dashboard">
  <h1>Dashboard</h1>
  <ul class="other-books-list">
    ${books.length > 0
      ? books.map(
          (book) => html` <li class="otherBooks">
            <h3>${book.title}</h3>
            <p>Type: ${book.type}</p>
            <p class="img"><img src=${book.imageUrl} /></p>
            <a class="button" href="/books/${book._id}">Details</a>
          </li>`
        )
      : html`<p class="no-books">No books in database!</p>`};
  </ul>
</section>`;

export const dashboardView = async () => {
  let books = await getAllBooks();
  render(dashboardTemplate(books), mainElement);
};

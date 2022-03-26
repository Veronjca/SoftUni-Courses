import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getBooksByAuthor } from "../handlers/requestHandler.js";

const mainElement = document.querySelector("#site-content");

const myBooksTemplate = (books) => html`<section id="my-books-page" class="my-books">
  <h1>My Books</h1>
  <ul class="my-books-list">
    ${books.length > 0
      ? books.map(
          (book) => html` <li class="otherBooks">
            <h3>${book.title}</h3>
            <p>Type: ${book.type}</p>
            <p class="img"><img src=${book.imageUrl} /></p>
            <a class="button" href="/books/${book._id}">Details</a>
          </li>`
        )
      : html`<p class="no-books">No books in database!</p>`}
  </ul>
</section>`;

export const myBooksView = async () => {
  let user = JSON.parse(sessionStorage.user);
  let books = await getBooksByAuthor(user._id);
  render(myBooksTemplate(books), mainElement);
};

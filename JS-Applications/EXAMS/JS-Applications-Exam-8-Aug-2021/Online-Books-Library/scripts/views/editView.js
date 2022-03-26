import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { editHandler } from "../handlers/editHandler.js";
import { getOneBook } from "../handlers/requestHandler.js";

const mainElement = document.querySelector("#site-content");

const editTemplate = (book) => html`<section id="edit-page" class="edit">
  <form @submit=${editHandler} id="edit-form" action="#" method="">
    <fieldset>
      <legend>Edit my Book</legend>
      <p class="field">
        <label for="title">Title</label>
        <span class="input">
          <input type="text" name="title" id="title" .value=${book.title} />
        </span>
      </p>
      <p class="field">
        <label for="description">Description</label>
        <span class="input">
          <textarea name="description" id="description" .value=${book.description}></textarea>
        </span>
      </p>
      <p class="field">
        <label for="image">Image</label>
        <span class="input">
          <input type="text" name="imageUrl" id="image" .value=${book.imageUrl} />
        </span>
      </p>
      <p class="field">
        <label for="type">Type</label>
        <span class="input">
          <select id="type" name="type" .value=${book.type}>
            <option value="Fiction" selected>Fiction</option>
            <option value="Romance">Romance</option>
            <option value="Mistery">Mistery</option>
            <option value="Classic">Clasic</option>
            <option value="Other">Other</option>
          </select>
        </span>
      </p>
      <input class="button submit" type="submit" value="Save" />
    </fieldset>
  </form>
</section>`;

export const editView = async (ctx) => {
  let book = await getOneBook(ctx.params.id);
  render(editTemplate(book), mainElement);
};

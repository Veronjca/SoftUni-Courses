import { editBook } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function editHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let title = formData.get("title");
  let description = formData.get("description");
  let imageUrl = formData.get("imageUrl");
  let type = formData.get("type");

  if (!title || !description || !imageUrl || !type) {
    alert("Please fill out all fields!");
    ev.currentTarget.reset();
    return;
  }

  let currentUrl = new URL(window.location.href);
  let index = currentUrl.pathname.lastIndexOf("/");
  let id = currentUrl.pathname.slice(index + 1);

  let edited = await editBook(id, title, description, imageUrl, type);

  if (edited) {
    page.redirect(`/books/${id}`);
  }
}

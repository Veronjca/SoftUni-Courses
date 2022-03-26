import { addBook } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function addBookHanlder(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let title = formData.get("title");
  let description = formData.get("description");
  let imageUrl = formData.get("imageUrl");
  let type = formData.get("type");

  if (!title || !description || !imageUrl || !type) {
    alert("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  }

  let book = await addBook(title, description, imageUrl, type);
  if (book) {
    page.redirect("/dashboard");
  }
}

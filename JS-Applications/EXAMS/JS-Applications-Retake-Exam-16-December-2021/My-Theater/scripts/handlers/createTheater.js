import { createTheater } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function createTheaterHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let title = formData.get("title");
  let date = formData.get("date");
  let author = formData.get('author');
  let imageUrl = formData.get("imageUrl");
  let description = formData.get("description");

  if (!title || !date || !author || !imageUrl || !description) {
    alert("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  }

  let game = await createTheater(title, date, author, imageUrl, description);
  if (game) {
    page.redirect("/");
  }
}
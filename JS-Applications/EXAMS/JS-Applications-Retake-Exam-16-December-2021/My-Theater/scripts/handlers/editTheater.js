import { editTheater } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function editTheaterHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let title = formData.get("title");
  let date = formData.get("date");
  let author = formData.get('author');
  let imageUrl = formData.get("imageUrl");
  let description = formData.get("description");

  if (!title || !date || !author || !imageUrl || !description) {
    alert("Please fill out all fields!");
    ev.currentTarget.reset();
    return;
  }

  let currentUrl = new URL(window.location.href);
  let index = currentUrl.pathname.lastIndexOf("/");
  let theaterId = currentUrl.pathname.slice(index + 1);

  let edited = await editTheater(theaterId, title, date, author, description, imageUrl);

  if (edited) {
    page.redirect(`/theaters/${theaterId}`);
  }
}
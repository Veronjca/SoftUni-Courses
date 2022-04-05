import { editMeme } from "./memeService.js";
import page from "../../node_modules/page/page.mjs";
import { notificationView } from "../views/notification.js";

export async function editMemeHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let title = formData.get("title");
  let imageUrl = formData.get("imageUrl");
  let description = formData.get("description");

  if (!title || !imageUrl || !description) {
    notificationView("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  }

  let currentUrl = new URL(window.location.href);
  let index = currentUrl.pathname.lastIndexOf("/");
  let memeId = currentUrl.pathname.slice(index + 1);

  let edited = await editMeme(memeId, title, description, imageUrl);

  if (edited) {
    page.redirect(`/memes/${memeId}`);
  }
}

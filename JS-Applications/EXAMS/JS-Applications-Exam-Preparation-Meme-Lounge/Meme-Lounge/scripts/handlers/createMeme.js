import { createMeme } from "./memeService.js";
import page from "../../node_modules/page/page.mjs";
import { notificationView } from "../views/notification.js";

export async function createMemeHandler(ev) {
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

  let meme = await createMeme(title, description, imageUrl);
  if (meme) {
    page.redirect("/all");
  }
}

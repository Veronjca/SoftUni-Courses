import { createGame } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function createGameHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let title = formData.get("title");
  let category = formData.get("category");
  let maxLevel = formData.get('maxLevel');
  let imageUrl = formData.get("imageUrl");
  let summary = formData.get("summary");

  if (!title || !category || !maxLevel || !imageUrl || !summary) {
    alert("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  }

  let game = await createGame(title, category, maxLevel, imageUrl, summary);
  if (game) {
    page.redirect("/");
  }
}
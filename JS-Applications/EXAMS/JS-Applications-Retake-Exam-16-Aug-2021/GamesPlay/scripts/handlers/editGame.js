import { editGame } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function editHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let title = formData.get("title");
  let category = formData.get("category");
  let maxLevel = formData.get('maxLevel');
  let imageUrl = formData.get("imageUrl");
  let summary = formData.get("summary");

  if (!title || !category || !maxLevel || !imageUrl || !summary) {
    alert("Please fill out all fields!");
    ev.currentTarget.reset();
    return;
  }

  let currentUrl = new URL(window.location.href);
  let index = currentUrl.pathname.lastIndexOf("/");
  let gameId = currentUrl.pathname.slice(index + 1);

  let edited = await editGame(gameId, title, category, maxLevel, imageUrl, summary);

  if (edited) {
    page.redirect(`/games/${gameId}`);
  }
}
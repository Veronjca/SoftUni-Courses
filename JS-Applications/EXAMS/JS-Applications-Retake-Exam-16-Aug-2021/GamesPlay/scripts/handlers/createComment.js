import { createAComment } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function createCommentHandler(ev) {
  ev.preventDefault();
  let gameId = ev.currentTarget.id;
  let formData = new FormData(ev.currentTarget);
  let comment = formData.get("comment").trim();

  if(!comment){
      alert('Comment field should not be empty.');
      ev.target.reset();
      return;
  }
  
  let created = await createAComment(gameId, comment);
  if (created) {
    ev.target.reset();
    page.redirect(`/games/${gameId}`);
  }
}

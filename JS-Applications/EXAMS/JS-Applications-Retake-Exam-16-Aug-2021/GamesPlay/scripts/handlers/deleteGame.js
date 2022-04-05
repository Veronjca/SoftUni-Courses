import { deleteAGame } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function deleteGameHandler(ev) {
  let confirmed = confirm("Are you sure you want to delete this game?");
  if (confirmed) {
    await deleteAGame(ev.currentTarget.id);
    page.redirect('/');
  }
}

import { deleteMeme } from "./memeService.js";
import page from "../../node_modules/page/page.mjs";

export async function deleteMemeHandler(ev) {
  let confirmed = confirm("Are you sure you want to delete that meme?");
  if (confirmed) {
    await deleteMeme(ev.target.id);
    page.redirect('/all');
  }
}
import { deleteAlbum } from "./musicAppService.js";
import page from "../../node_modules/page/page.mjs";

export async function deleteAlbumHandler(ev) {
  let confirmed = confirm("Are you sure you want to delete this album?");
  if (confirmed) {
    await deleteAlbum(ev.target.id);
    page.redirect('/catalog');
  }
}
import { createAlbum } from "./musicAppService.js";
import page from "../../node_modules/page/page.mjs";

export async function createAlbumHandler(ev) {
  ev.preventDefault();
  let formData = new FormData(ev.currentTarget);
  let name = formData.get("name");
  let imgUrl = formData.get("imgUrl");
  let price = formData.get("price");
  let releaseDate = formData.get("releaseDate");
  let artist = formData.get("artist");
  let genre = formData.get('genre');
  let description = formData.get("description");

  if (!name || !imgUrl ||  !price || !releaseDate || !artist || !genre || !description) {
   alert("Please fill out all fields.");
    ev.currentTarget.reset();
    return;
  }

  let album = await createAlbum(name, imgUrl, price, releaseDate, artist, genre, description);
  if (album) {
    page.redirect("/catalog");
  }
}
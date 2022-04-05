import { html, nothing, render } from "../../node_modules/lit-html/lit-html.js";
import { getAllAlbums } from "../handlers/musicAppService.js";

const mainContainer = document.getElementById("main-content");

const catalogTemplate = (albums) => html` <section id="catalogPage">
  <h1>All Albums</h1>
  ${albums.length > 0
    ? html`${albums.map(
        (album) => html`<div class="card-box">
          <img src=${album.imgUrl} />
          <div>
            <div class="text-center">
              <p class="name">Name: ${album.name}</p>
              <p class="artist">Artist: ${album.artist}</p>
              <p class="genre">Genre: ${album.genre}</p>
              <p class="price">Price: ${album.price}</p>
              <p class="date">Release Date: ${album.releaseDate}</p>
            </div>
            <div class="btn-group">${sessionStorage.user ? html`<a href="/albums/${album._id}" id="details">Details</a>` : nothing}</div>
          </div>
        </div>`
      )}`
    : html`<p>No Albums in Catalog!</p>`}
</section>`;

export const catalogView = async () => {
  let albums = await getAllAlbums();
  render(catalogTemplate(albums), mainContainer);
};

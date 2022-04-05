import { html, nothing, render } from "../../node_modules/lit-html/lit-html.js";
import { getAlbum } from "../handlers/musicAppService.js";
import {deleteAlbumHandler} from "../handlers/deleteAlbum.js"

const mainContainer = document.getElementById("main-content");

const detailsTemplate = (album, isOwner) => html`<section id="detailsPage">
  <div class="wrapper">
    <div class="albumCover">
      <img src=${album.imgUrl} />
    </div>
    <div class="albumInfo">
      <div class="albumText">
        <h1>Name: ${album.name}</h1>
        <h3>Artist: ${album.artist}</h3>
        <h4>Genre: ${album.genre}</h4>
        <h4>Price: $${album.price}</h4>
        <h4>Date: ${album.releaseDate}</h4>
        <p>Description: ${album.description}</p>
      </div>

      <div class="actionBtn">${isOwner ? html`<a href="/edit/${album._id}" class="edit">Edit</a> <a id=${album._id} @click=${deleteAlbumHandler} href="javascript:void(0)" class="remove">Delete</a>` : nothing}</div>
    </div>
  </div>
</section>`;

export const detailsView = async (ctx) => {
  let album = await getAlbum(ctx.params.albumId);
  let isOwner = false;

  if (sessionStorage.user) {
    let user = JSON.parse(sessionStorage.user);
    isOwner = user._id === album._ownerId;
  }
  render(detailsTemplate(album, isOwner), mainContainer);
};

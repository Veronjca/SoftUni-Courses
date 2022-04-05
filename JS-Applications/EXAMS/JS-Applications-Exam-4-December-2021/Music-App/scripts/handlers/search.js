import { html, nothing, render } from "../../node_modules/lit-html/lit-html.js";
import { searchByName } from "./musicAppService.js";

export async function searchHandler(ev) {
  let query = ev.currentTarget.previousElementSibling.value;
  let matches = await searchByName(query);
  let searchResultContainer = document.querySelector(".search-result");

  const matchesTemplate = (albums) =>
    html`${albums.length > 0
      ? albums.map(
          (album) => html` <div class="card-box">
            <img src=${album.imgUrl} />
            <div>
              <div class="text-center">
                <p class="name">Name: ${album.name}</p>
                <p class="artist">Artist: ${album.artist}</p>
                <p class="genre">Genre: ${album.genre}</p>
                <p class="price">Price: $${album.price}</p>
                <p class="date">Release Date: ${album.releaseDate}</p>
              </div>
              <div class="btn-group">${sessionStorage.user ? html` <a href="/albums/${album._id}" id="details">Details</a>` : nothing}</div>
            </div>
          </div>`
        )
      : html`<p class="no-result">No result.</p>`}`;

  render(matchesTemplate(matches), searchResultContainer);
}

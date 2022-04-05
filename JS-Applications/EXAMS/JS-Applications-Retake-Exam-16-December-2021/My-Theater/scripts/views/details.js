import { html, nothing, render } from "../../node_modules/lit-html/lit-html.js";
import { deleteTheaterHandler } from "../handlers/deleteTheater.js";
import { likeTheater } from "../handlers/likeTheater.js";
import { getLikeForSpecificUser, getLikes, getTheater } from "../handlers/requestHandler.js";

const mainContainer = document.getElementById("content");

const detailsTemplate = (theater, isOwner, isLiked, likes) => html`<section id="detailsPage">
  <div id="detailsBox">
    <div class="detailsInfo">
      <h1>Title: ${theater.title}</h1>
      <div>
        <img src=${theater.imageUrl} />
      </div>
    </div>

    <div class="details">
      <h3>Theater Description</h3>
      <p>${theater.description}</p>
      <h4>Date: ${theater.date}</h4>
      <h4>Author: ${theater.author}</h4>
      <div class="buttons">
        ${isOwner
          ? html` <a id=${theater._id} @click=${deleteTheaterHandler} class="btn-delete" href="javascript:void(0)">Delete</a>
              <a class="btn-edit" href="/edit/${theater._id}">Edit</a>`
          : nothing}
        ${sessionStorage.user && !isOwner && !isLiked ? html` <a id=${theater._id} @click=${likeTheater} class="btn-like" href="">Like</a>` : nothing}
      </div>
      <p class="likes">Likes: ${likes}</p>
    </div>
  </div>
</section>`;

export const detailsView = async (ctx) => {
  let isOwner = false;
  let isLiked = false;
  let theater = await getTheater(ctx.params.id);
  let likes = await getLikes(ctx.params.id);

  if (sessionStorage.user) {
    let user = JSON.parse(sessionStorage.user);
    isOwner = theater._ownerId === user._id;
    let like = await getLikeForSpecificUser(ctx.params.id, user._id);
    isLiked = like > 0;
  }
  render(detailsTemplate(theater, isOwner, isLiked, likes), mainContainer);
};

import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getMemesForSpecificUser } from "../handlers/memeService.js";

const mainContainer = document.getElementsByTagName("main")[0];

const profileTemplate = (user, memeCount, memes) => html`<section id="user-profile-page" class="user-profile">
  <article class="user-info">
    <img id="user-avatar-url" alt="user-profile" src=${user.gender === "female" ? "/images/female.png" : "/images/male.png"} />
    <div class="user-content">
      <p>Username: ${user.username}</p>
      <p>Email: ${user.email}</p>
      <p>My memes count: ${memeCount}</p>
    </div>
  </article>
  <h1 id="user-listings-title">User Memes</h1>
  <div class="user-meme-listings">
    ${memes.length > 0
      ? html`${memes.map(
          (m) => html`<div class="user-meme">
            <p class="user-meme-title">${m.title}</p>
            <img class="userProfileImage" alt="meme-img" src=${m.imageUrl} />
            <a class="button" href="/memes/${m._id}">Details</a>
          </div>`
        )}`
      : html` <p class="no-memes">No memes in database.</p>`}
  </div>
</section> `;

export const profileView = async () => {
  let user = JSON.parse(sessionStorage.user);
  let memes = await getMemesForSpecificUser(user._id);
  render(profileTemplate(user, memes.length, memes), mainContainer);
};

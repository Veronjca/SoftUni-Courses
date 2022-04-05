import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { getEventsForSpecificUser } from "../handlers/requestHandler.js";

const mainContainer = document.getElementById("content");

const profileTemplate = (user, events) => html`<section id="profilePage">
  <div class="userInfo">
    <div class="avatar">
      <img src="./images/profilePic.png" />
    </div>
    <h2>${user.email}</h2>
  </div>
  <div class="board">
    ${events.length > 0
      ? html`${events.map(
          (e) => html` <div class="eventBoard">
            <div class="event-info">
              <img src=${e.imageUrl} />
              <h2>${e.title}</h2>
              <h6>${e.date}</h6>
              <a href="/details/${e._id}" class="details-button">Details</a>
            </div>
          </div>`
        )}`
      : html` <div class="no-events">
          <p>This user has no events yet!</p>
        </div>`}
  </div>
</section>`;

export const profileView = async () => {
  let user = JSON.parse(sessionStorage.user);
  let events = await getEventsForSpecificUser(user._id);
  render(profileTemplate(user, events), mainContainer);
};

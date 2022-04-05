import { html, render } from "../../node_modules/lit-html/lit-html.js";

const notificationContainer = document.getElementById("notifications");

const notificationTemplate = (message) => html`<div id="errorBox" class="notification">
  <span>${message}</span>
</div>`;

export const notificationView = (message) => {
  render(notificationTemplate(message), notificationContainer);
  setTimeout(() => {notificationContainer.innerHTML = ""}, 3000);
};

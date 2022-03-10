import * as renderer from "./renderers.js";

function appendTopic(data) {
  let main = document.querySelector("main");
  let divs = main.querySelectorAll(".topic-container");
  divs.forEach((x) => x.remove());

  for (const [key, value] of Object.entries(data)) {
    let container = renderer.renderPost(key, value.title, value.username, value.createdOn, value.post);
    main.appendChild(container);
  }
}

export {appendTopic};

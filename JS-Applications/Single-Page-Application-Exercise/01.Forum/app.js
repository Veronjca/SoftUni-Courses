import * as utilities from "./utils.js";
import * as requests from "./requests.js";
import * as renderer from "./renderers.js";

let home = document.querySelector('#home');
home.addEventListener('click', async () => {
  renderer.renderHomePage();
  let data = await requests.getAllTopics();
  utilities.appendTopic(data);
})

window.addEventListener("load", async () => {
  renderer.renderHomePage();
  let data = await requests.getAllTopics();
  utilities.appendTopic(data);
});

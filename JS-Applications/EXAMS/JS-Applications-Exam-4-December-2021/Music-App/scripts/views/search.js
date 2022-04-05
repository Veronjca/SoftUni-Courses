import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { searchHandler } from "../handlers/search.js";

const mainContainer = document.getElementById("main-content");

const searchTemplate = () => html` <section id="searchPage">
  <h1>Search by Name</h1>

  <div class="search">
    <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name" />
    <button @click=${searchHandler} class="button-list">Search</button>
  </div>

  <h2>Results:</h2>
  <!--Show after click Search button-->
  <div class="search-result"></div>
</section>`;

export const searchView = () => {
  render(searchTemplate(), mainContainer);
};

import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { createMemeHandler } from "../handlers/createMeme.js";

const mainContainer = document.getElementsByTagName("main")[0];

const createMemeTemplate = () => html`  <section id="create-meme">
<form @submit=${createMemeHandler} id="create-form">
    <div class="container">
        <h1>Create Meme</h1>
        <label for="title">Title</label>
        <input id="title" type="text" placeholder="Enter Title" name="title">
        <label for="description">Description</label>
        <textarea id="description" placeholder="Enter Description" name="description"></textarea>
        <label for="imageUrl">Meme Image</label>
        <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
        <input type="submit" class="registerbtn button" value="Create Meme">
    </div>
</form>
</section>`;

export const createMemeView = () => {
    render(createMemeTemplate(), mainContainer);
}
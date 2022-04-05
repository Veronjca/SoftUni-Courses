import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { editMemeHandler } from "../handlers/editMeme.js";
import { getMeme } from "../handlers/memeService.js";

const mainContainer = document.getElementsByTagName("main")[0];

const editTemplate = (meme) => html`<section id="edit-meme">
  <form @submit=${editMemeHandler} id="edit-form">
    <h1>Edit Meme</h1>
    <div class="container">
      <label for="title">Title</label>
      <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title} />
      <label for="description">Description</label>
      <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}>
                Programming is often touted as a smart and lucrative career path.
                It's a job that (sometimes) offers flexibility and great benefits.
                But it's far from sunshine and Nyan Cat rainbows. The hours are long.
                The mistakes are frustrating. And your eyesight is almost guaranteed to suffer.
                These memes cover most of the frustration (and funny moments) of programming.
                At least we can laugh through the pain. 
            </textarea
      >
      <label for="imageUrl">Image Url</label>
      <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl} />
      <input type="submit" class="registerbtn button" value="Edit Meme" />
    </div>
  </form>
</section>`;

export const editView = async (ctx) => {
  let meme = await getMeme(ctx.params.memeId);
  render(editTemplate(meme), mainContainer);
};

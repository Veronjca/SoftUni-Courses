import { html, render } from "../../node_modules/lit-html/lit-html.js";
import { editTheaterHandler } from "../handlers/editTheater.js";
import { getTheater } from "../handlers/requestHandler.js";

const mainContainer = document.getElementById("content");

const editTemplate = (theater) => html`<section id="editPage">
<form @submit=${editTheaterHandler} class="theater-form">
    <h1>Edit Theater</h1>
    <div>
        <label for="title">Title:</label>
        <input id="title" name="title" type="text" placeholder="Theater name" .value=${theater.title}>
    </div>
    <div>
        <label for="date">Date:</label>
        <input id="date" name="date" type="text" placeholder="Month Day, Year" .value=${theater.date}>
    </div>
    <div>
        <label for="author">Author:</label>
        <input id="author" name="author" type="text" placeholder="Author"
            .value=${theater.author}>
    </div>
    <div>
        <label for="description">Theater Description:</label>
        <textarea id="description" name="description"
           .value=${theater.description} placeholder="Description">To Kill a Mockingbird is a 2018 play based on the 1960 novel of the same name by Harper Lee, adapted for the stage by Aaron Sorkin. It opened on Broadway at the Shubert Theatre on December 13, 2018. The play is set to transfer to London's West End at the Gielgud Theatre in March 2022.</textarea>
    </div>
    <div>
        <label for="imageUrl">Image url:</label>
        <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url"
            value=${theater.imageUrl}>
    </div>
    <button class="btn" type="submit">Submit</button>
</form>
</section>`;

export const editView = async (ctx) => {
    let theater = await getTheater(ctx.params.id);
    render(editTemplate(theater), mainContainer);
}
import { deleteTheater } from "./requestHandler.js";
import page from "../../node_modules/page/page.mjs";

export async function deleteTheaterHandler(ev) {
  let confirmed = confirm("Are you sure you want to delete this theater?");
  if (confirmed) {
    await deleteTheater(ev.target.id);
    page.redirect('/profile');
  }
}
import { likeSpecificTheater } from "./requestHandler.js";
import page  from "../../node_modules/page/page.mjs";

export async function likeTheater(ev) {
  let liked = await likeSpecificTheater(ev.target.id);
  if (liked) {
    page.redirect(`/theaters/${ev.target.id}`);
  }
}

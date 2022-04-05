import * as api from "../requestTemplate.js";

const host = "http://localhost:3030";
const registerEndpoint = `${host}/users/register`;
const loginEndpoint = `${host}/users/login`;
const logoutEndpoint = `${host}/users/logout`;
const memesEndpoint = `${host}/data/memes`;

async function registerUser(username, email, password, gender) {
  return api.post(registerEndpoint, { username, email, password, gender });
}

async function loginUser(email, password) {
  return api.post(loginEndpoint, { email, password });
}

async function logoutUser() {
  return api.get(logoutEndpoint);
}

async function createMeme(title, description, imageUrl) {
  return api.post(memesEndpoint, { title, description, imageUrl });
}
async function getAllMemes() {
  return api.get(host + "/data/memes?sortBy=_createdOn%20desc");
}

async function getMeme(memeId) {
  return api.get(memesEndpoint + "/" + memeId);
}

async function editMeme(memeId, title, description, imageUrl) {
  return api.put(memesEndpoint + "/" + memeId, { title, description, imageUrl });
}

async function deleteMeme(memeId) {
  return api.delete(memesEndpoint + "/" + memeId);
}

async function getMemesForSpecificUser(userId) {
  return api.get(host + `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}
export { loginUser, registerUser, logoutUser, createMeme, getAllMemes, getMeme, editMeme, deleteMeme, getMemesForSpecificUser };

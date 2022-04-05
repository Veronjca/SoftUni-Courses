import * as api from "../requestTemplate.js";

const host = "http://localhost:3030";
const registerEndpoint = `${host}/users/register`;
const loginEndpoint = `${host}/users/login`;
const logoutEndpoint = `${host}/users/logout`;
const albumsEndpoint = `${host}/data/albums`;

async function registerUser(email, password) {
  return api.post(registerEndpoint, { email, password });
}

async function loginUser(email, password) {
  return api.post(loginEndpoint, { email, password });
}

async function logoutUser() {
  return api.get(logoutEndpoint);
}

async function getAllAlbums() {
  return api.get(albumsEndpoint + "?sortBy=_createdOn%20desc&distinct=name");
}

async function createAlbum(name, imgUrl, price, releaseDate, artist, genre, description) {
  return api.post(albumsEndpoint, { name, imgUrl, price, releaseDate, artist, genre, description });
}

async function getAlbum(albumId) {
  return api.get(albumsEndpoint + "/" + albumId);
}

async function editAlbum(albumId, name, imgUrl, price, releaseDate, artist, genre, description) {
  return api.put(albumsEndpoint + "/" + albumId, { name, imgUrl, price, releaseDate, artist, genre, description });
}

async function deleteAlbum(albumId) {
  return api.delete(albumsEndpoint + "/" + albumId);
}

async function searchByName(query) {
  return api.get(albumsEndpoint + `?where=name%20LIKE%20%22${query}%22`);
}
export { registerUser, loginUser, logoutUser, getAllAlbums, createAlbum, getAlbum, editAlbum, deleteAlbum, searchByName };

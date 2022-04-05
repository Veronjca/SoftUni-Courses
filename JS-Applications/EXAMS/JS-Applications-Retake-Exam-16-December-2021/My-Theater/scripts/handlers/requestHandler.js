import * as api from "../requestTemplate.js";

const host = "http://localhost:3030";
const registerEndpoint = `${host}/users/register`;
const loginEndpoint = `${host}/users/login`;
const logoutEndpoint = `${host}/users/logout`;
const theatersEndpoint = `${host}/data/theaters`;

async function registerUser(email, password) {
  return api.post(registerEndpoint, { email, password });
}

async function loginUser(email, password) {
  return api.post(loginEndpoint, { email, password });
}

async function logoutUser() {
  return api.get(logoutEndpoint);
}

async function getAllTheaters() {
  return api.get(theatersEndpoint + `?sortBy=_createdOn%20desc&distinct=title`);
}

async function createTheater(title, date, author, imageUrl, description) {
  return api.post(theatersEndpoint, { title, date, author, imageUrl, description });
}

async function getTheater(id) {
  return api.get(theatersEndpoint + "/" + id);
}

async function editTheater(theaterId, title, date, author, description, imageUrl) {
  return api.put(theatersEndpoint + "/" + theaterId, { title, date, author, description, imageUrl });
}

async function deleteTheater(theaterId) {
  return api.delete(theatersEndpoint + "/" + theaterId);
}

async function getEventsForSpecificUser(userId) {
  return api.get(host + `/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

async function getLikes(theaterId) {
  return api.get(host + `/data/likes?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`);
}

async function likeSpecificTheater(theaterId) {
  return api.post(host + "/data/likes", { theaterId });
}

async function getLikeForSpecificUser(theaterId, userId) {
  return api.get(host + `/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}
export {
  registerUser,
  loginUser,
  logoutUser,
  getAllTheaters,
  createTheater,
  getTheater,
  editTheater,
  deleteTheater,
  getEventsForSpecificUser,
  getLikes,
  likeSpecificTheater,
  getLikeForSpecificUser,
};

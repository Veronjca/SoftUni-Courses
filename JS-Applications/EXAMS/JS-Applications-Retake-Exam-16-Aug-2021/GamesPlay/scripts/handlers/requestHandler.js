import * as api from "../requestTemplate.js";

const host = "http://localhost:3030";
const registerEndpoint = `${host}/users/register`;
const loginEndpoint = `${host}/users/login`;
const logoutEndpoint = `${host}/users/logout`;
const gamesEndpoint = `${host}/data/games`;

async function registerUser(email, password) {
  return api.post(registerEndpoint, { email, password });
}

async function loginUser(email, password) {
  return api.post(loginEndpoint, { email, password });
}

async function logoutUser() {
  return api.get(logoutEndpoint);
}

async function getAllGames() {
  return api.get(gamesEndpoint + "?sortBy=_createdOn%20desc");
}

async function getThreeMostRecentGames() {
  return api.get(gamesEndpoint + "?sortBy=_createdOn%20desc&distinct=category");
}

async function createGame(title, category, maxLevel, imageUrl, summary) {
  return api.post(gamesEndpoint, { title, category, maxLevel, imageUrl, summary });
}

async function getOneGame(gameId) {
  return api.get(gamesEndpoint + "/" + gameId);
}

async function editGame(gameId, title, category, maxLevel, imageUrl, summary) {
  return api.put(gamesEndpoint + "/" + gameId, { title, category, maxLevel, imageUrl, summary });
}

async function deleteAGame(gameId) {
  return api.delete(gamesEndpoint + "/" + gameId);
}

async function getAllCommentsForSpecificGame(gameId) {
  return api.get(`${host}/data/comments?where=gameId%3D%22${gameId}%22`);
}

async function createAComment (gameId, comment){
  return api.post(`${host}/data/comments`, {gameId, comment});
}
export {
  registerUser,
  loginUser,
  logoutUser,
  getAllGames,
  getThreeMostRecentGames,
  createGame,
  getOneGame,
  editGame,
  deleteAGame,
  getAllCommentsForSpecificGame,
  createAComment
};

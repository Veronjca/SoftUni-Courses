import * as api from "./requestTemplate.js";

const registerEndpoint = "http://localhost:3030/users/register";
const loginEndpoint = "http://localhost:3030/users/login";
const logoutEndpoint = "http://localhost:3030/users/logout";
const getAllIdeasEndpoint = "http://localhost:3030/data/ideas";
const createNewIdeaEndpoint = " http://localhost:3030/data/ideas";

async function registerUser(email, password) {
  return await api.post(registerEndpoint, { email, password });
}

async function loginUser(email, password) {
  return await api.post(loginEndpoint, { email, password });
}

async function logoutUser() {
  return await api.get(logoutEndpoint);
}

async function getAllIdeas() {
  return await api.get(getAllIdeasEndpoint);
}

async function createNewIdea(title, description, img) {
  return await api.post(createNewIdeaEndpoint, { title, description, img });
}

async function getIdeaDetails(id) {
  return await api.get(`${createNewIdeaEndpoint}/${id}`);
}

async function deleteIdea(id) {
  return await api.delete(`${createNewIdeaEndpoint}/${id}`);
}
export { registerUser, loginUser, logoutUser, getAllIdeas, createNewIdea, getIdeaDetails, deleteIdea};

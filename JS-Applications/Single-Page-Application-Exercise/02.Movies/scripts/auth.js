import * as api from "./api.js";

let loginURL = "http://localhost:3030/users/login";
let registerURL = "http://localhost:3030/users/register";
let logoutURL = "http://localhost:3030/users/logout";
let moviesURL = "http://localhost:3030/data/movies";
let likesURL = 'http://localhost:3030/data/likes';

async function login(email, password) {
  return await api.post(loginURL, { email, password });
}

async function register(email, password) {
  return await api.post(registerURL, { email, password });
}

async function logout() {
  return await api.get(logoutURL);
}

async function getAllMovies() {
  return await api.get(moviesURL);
}

async function createMovie(title, description, img) {
  return await api.post(moviesURL, { title, description, img });
}

async function getMovieDetails(id) {
  return await api.get(`${moviesURL}/${id}`);
}

async function editMovieDetails(id, title, description, img) {
  return await api.put(`${moviesURL}/${id}`, { title, description, img });
}

async function sendLike(movieId){
  return await api.post(likesURL, {movieId});
}

async function getLikes(){
  return await api.get(likesURL);
}

async function deleteMovie(id){
  return await api.delete(`${moviesURL}/${id}`);
}

export { login, register, logout, getAllMovies, createMovie, getMovieDetails, editMovieDetails, sendLike, getLikes, deleteMovie};

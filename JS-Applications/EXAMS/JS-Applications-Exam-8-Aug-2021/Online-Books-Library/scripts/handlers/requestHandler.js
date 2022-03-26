import * as api from "../requestTemplate.js";

const registerEndpoint = "http://localhost:3030/users/register";
const loginEndpoint = "http://localhost:3030/users/login";
const logoutEndpoint = "http://localhost:3030/users/logout";
const getAllBooksEndpoint = "http://localhost:3030/data/books?sortBy=_createdOn%20desc";
const booksEndpoint = " http://localhost:3030/data/books";
const likeABookEndpoint = " http://localhost:3030/data/likes";

async function registerUser(email, password) {
  return api.post(registerEndpoint, { email, password });
}

async function loginUser(email, password) {
  return api.post(loginEndpoint, { email, password });
}

async function logoutUser() {
  return api.get(logoutEndpoint);
}

async function getOneBook(id) {
  return api.get(`${booksEndpoint}/${id}`);
}

async function getAllBooks() {
  return api.get(getAllBooksEndpoint);
}

async function addBook(title, description, imageUrl, type) {
  return api.post(booksEndpoint, { title, description, imageUrl, type });
}

async function getBookDetails(id) {
  return api.get(`${booksEndpoint}/${id}`);
}

async function deleteBook(id) {
  return api.delete(`${booksEndpoint}/${id}`);
}

async function editBook(id, title, description, imageUrl, type) {
  return api.put(`${booksEndpoint}/${id}`, { title, description, imageUrl, type });
}

async function getBooksByAuthor(id) {
  return api.get(`http://localhost:3030/data/books?where=_ownerId%3D%22${id}%22&sortBy=_createdOn%20desc`);
}

async function likeABook(bookId) {
  return api.post(likeABookEndpoint, { bookId });
}

async function getAllLikes(bookId) {
  return api.get(likeABookEndpoint + `?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
}

async function getLikesFromSpecificUser(bookId, userId) {
  return api.get(likeABookEndpoint + `?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}
export {
  registerUser,
  loginUser,
  logoutUser,
  getAllBooks,
  addBook,
  getBookDetails,
  deleteBook,
  getOneBook,
  editBook,
  getBooksByAuthor,
  likeABook,
  getAllLikes,
  getLikesFromSpecificUser
};

import * as auth from "./auth.js";
import { displayCorrectNavigation } from "./navigation.js";
import { setGreeting } from "./setGreeting.js";

const homePage = document.querySelector("#home-page");
const allMoviesSection = document.querySelector("#movie");
const moviesContainer = allMoviesSection.querySelector(".card-deck");
const addMovieButtonSection = document.querySelector("#add-movie-button");
const editMovieSection = document.querySelector("#edit-movie");
const loginSection = document.querySelector("#form-login");
const loginForm = loginSection.querySelector("form");
const registerSection = document.querySelector("#form-sign-up");
const registerForm = registerSection.querySelector("form");
const container = document.querySelector("#container");
const navBar = document.querySelector(".navbar");
const addMovieButton = homePage.querySelector(".btn-warning");
const addMovieForm = document.querySelector("#add-movie").querySelector("form");
addMovieForm.addEventListener("submit", (ev) => {
  ev.preventDefault();
  let formData = new FormData(addMovieForm);
  let title = formData.get("title");
  let description = formData.get("description");
  let img = formData.get("imageUrl");
  auth.createMovie(title, description, img);
  showHomePage();
});

async function deleteMovieRecord(ev) {
  ev.preventDefault();
  await auth.deleteMovie(ev.target.id);
  showHomePage();
}
async function likeMovie(ev) {
  ev.preventDefault();
  await auth.sendLike(ev.target.id);
  let likes = await auth.getLikes();
  likes = likes.filter((x) => x.movieId === ev.target.id);

  ev.target.nextElementSibling.textContent = `Liked ${likes.length}`;
  ev.target.remove();
}

async function editMovie(event) {
  event.preventDefault();
  container.replaceChildren(navBar);
  let movie = await auth.getMovieDetails(event.currentTarget.id);
  let editForm = editMovieSection.querySelector("form");

  editForm.querySelector("#title").value = movie.title;
  editForm.querySelector("#description").value = movie.description;
  editForm.querySelector("#imageUrl").value = movie.img;
  editForm.addEventListener("submit", async (ev) => {
    ev.preventDefault();
    let formData = new FormData(editForm);
    let title = formData.get("title");
    let description = formData.get("description");
    let img = formData.get("imageUrl");
    let edited = await auth.editMovieDetails(movie._id, title, description, img);
    if (edited) {
      showMovieDetails(event);
    }
  });

  container.appendChild(editMovieSection);
}

async function showMovieDetails(ev) {
  ev.preventDefault();
  if (!sessionStorage.user) {
    return;
  }

  let movie = await auth.getMovieDetails(ev.target.id);
  let likes = await auth.getLikes();
  let totalLikesForTheMovie = likes.filter((x) => x.movieId === ev.target.id);
  let user = JSON.parse(sessionStorage.user);
  let isLiked = () => {
    if (likes.some((x) => x.movieId === ev.target.id && x._ownerId === user._id)) {
      return true;
    }
    return false;
  };

  container.replaceChildren(navBar);
  container.innerHTML += `
  <section id="movie-example">
    <div class="container">
      <div class="row bg-light text-dark">
        <h1>Movie title: ${movie.title}</h1>
        <div class="col-md-8">
          <img class="img-thumbnail" src=${movie.img} alt="Movie" />
        </div>
        <div class="col-md-4 text-center">
          <h3 class="my-3">Movie Description</h3>
          <p>${movie.description}</p>
          <a id=${movie._id} class="btn btn-danger" style="display: ${user._id === movie._ownerId ? "inline" : "none"};" href="">Delete</a>
          <a id=${movie._id} class="btn btn-warning" href="" style="display: ${user._id === movie._ownerId ? "inline" : "none"};">Edit</a>
          <a id=${movie._id} class="btn btn-primary" href="" style="display: ${
    user._id === movie._ownerId || isLiked() ? "none" : "inline"
  };">Like</a>
          <span class="enrolled-span">Likes: ${totalLikesForTheMovie.length}</span>
        </div>
      </div>
    </div>
  </section>`;

  let editButton = container.querySelector(".btn-warning");
  editButton.addEventListener("click", editMovie);

  let likeButton = container.querySelector(".btn-primary");
  likeButton.addEventListener("click", likeMovie);

  let deleteButton = container.querySelector(".btn-danger");
  deleteButton.addEventListener("click", deleteMovieRecord);
}

function showAddMovieForm(ev) {
  ev.preventDefault();
  let addMovieFragment = document.createDocumentFragment();
  addMovieFragment.appendChild(navBar);
  addMovieFragment.appendChild(addMovieForm);
  container.replaceChildren(addMovieFragment);
}

async function showMovies() {
  let allMovies = await auth.getAllMovies();
  allMovies = allMovies.map(
    (movie) => `<div id=${movie._ownerId} class="card mb-4">
<img class="card-img-top" src=${movie.img} alt="Card image cap" width="400" />
<div class="card-body">
  <h4 class="card-title">${movie.title}</h4>
</div>
<div class="card-footer">
    <button type="button" id=${movie._id} class="btn btn-info">Details</button>
</div>
</div>`
  );
  moviesContainer.innerHTML = "";
  allMovies.forEach((movie) => (moviesContainer.innerHTML += movie));
  let allButtons = moviesContainer.querySelectorAll(".btn-info");
  allButtons.forEach((button) => button.addEventListener("click", showMovieDetails));
}

function showHomePage() {
  let homeFragment = document.createDocumentFragment();
  homeFragment.appendChild(navBar);
  homeFragment.appendChild(homePage);
  homeFragment.appendChild(allMoviesSection);
  container.replaceChildren(homeFragment);
  displayCorrectNavigation();

  if (sessionStorage.user) {
    homePage.appendChild(addMovieButtonSection);
    addMovieButton.addEventListener("click", showAddMovieForm);
  } else {
    addMovieButtonSection.remove();
  }

  showMovies();
  setGreeting();
}

function showLoginPage() {
  container.replaceChildren(navBar);
  container.appendChild(loginForm);
  loginForm.addEventListener("submit", loginUser);

  async function loginUser(ev) {
    ev.preventDefault();
    let formData = new FormData(loginForm);
    let email = formData.get("email");
    let password = formData.get("password");
    const user = await auth.login(email, password);

    if (user) {
      sessionStorage.setItem("user", JSON.stringify(user));
      showHomePage();
    }
    loginForm.reset();
    displayCorrectNavigation();
    setGreeting();
  }
  displayCorrectNavigation();
  setGreeting();
}

function showRegisterPage() {
  container.replaceChildren(navBar);
  container.appendChild(registerSection);
  registerForm.addEventListener("submit", registerUser);

  async function registerUser(ev) {
    ev.preventDefault();
    let formData = new FormData(registerForm);
    let email = formData.get("email");
    let password = formData.get("password");
    let repeatedPassword = formData.get("repeatPassword");

    if (password !== repeatedPassword || password.length < 6 || !email) {
      alert("Invalid data!");
      registerForm.reset();
      return;
    }
    const user = await auth.register(email, password);

    if (user) {
      sessionStorage.setItem("user", JSON.stringify(user));
      showHomePage();
    }
    registerForm.reset();
    displayCorrectNavigation();
    setGreeting();
  }
  displayCorrectNavigation();
  setGreeting();
}

export { showHomePage, showLoginPage, showRegisterPage };

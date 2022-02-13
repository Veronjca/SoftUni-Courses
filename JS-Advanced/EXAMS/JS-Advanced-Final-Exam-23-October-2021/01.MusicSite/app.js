window.addEventListener("load", solve);

function solve() {
  let genreInputElement = document.querySelector("#genre");
  let songNameInputElement = document.querySelector("#name");
  let authorInputElement = document.querySelector("#author");
  let dateInputElement = document.querySelector("#date");
  let songsCollectionElement = document.querySelector(".all-hits-container");
  let totalLikesElement = document.querySelector(".likes").children[0];
  let savedSongsElement = document.querySelector(".saved-container");
  let addButton = document.querySelector("#add-btn");
  addButton.addEventListener("click", (ev) => {
      ev.preventDefault();
    let genre = genreInputElement.value;
    let songName = songNameInputElement.value;
    let author = authorInputElement.value;
    let date = dateInputElement.value;

    genreInputElement.value = "";
    songNameInputElement.value = "";
    authorInputElement.value = "";
    dateInputElement.value = "";

    if (genre && songName && author && date) {
      let divElement = document.createElement("div");
      let imgElement = document.createElement("img");
      let genreH2Element = document.createElement("h2");
      let nameH2Element = document.createElement("h2");
      let authorH2Element = document.createElement("h2");
      let dateH3Element = document.createElement("h3");
      let likeButton = document.createElement("button");
      let saveButton = document.createElement("button");
      let deleteButton = document.createElement("button");

      divElement.classList.add("hits-info");
      imgElement.src = "./static/img/img.png";
      genreH2Element.textContent = `Genre: ${genre}`;
      nameH2Element.textContent = `Name: ${songName}`;
      authorH2Element.textContent = `Author: ${author}`;
      dateH3Element.textContent = `Date: ${date}`;
      likeButton.classList.add("like-btn");
      likeButton.textContent = 'Like song';
      saveButton.classList.add("save-btn");
      saveButton.textContent = 'Save song';
      deleteButton.classList.add("delete-btn");
      deleteButton.textContent = 'Delete';

      divElement.appendChild(imgElement);
      divElement.appendChild(genreH2Element);
      divElement.appendChild(nameH2Element);
      divElement.appendChild(authorH2Element);
      divElement.appendChild(dateH3Element);
      divElement.appendChild(saveButton);
      divElement.appendChild(likeButton);
      divElement.appendChild(deleteButton);

      likeButton.addEventListener("click", (ev) => {
          ev.preventDefault();
        let text = totalLikesElement.textContent.split(" ");
        let likes = Number(text[text.length - 1]);
        likes++;
        totalLikesElement.textContent = `Total Likes: ${likes}`;
        ev.currentTarget.disabled = true;
      });

      saveButton.addEventListener("click", () => {
        savedSongsElement.appendChild(divElement);
       likeButton.remove();
        saveButton.remove();
      });

      deleteButton.addEventListener('click', () => {
          divElement.remove();
      })

      songsCollectionElement.appendChild(divElement);
    }
  });
}

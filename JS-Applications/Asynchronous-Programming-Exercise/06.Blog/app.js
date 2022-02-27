async function attachEvents() {
  let baseURL = "http://localhost:3030/jsonstore/blog/";

  let loadPostsButton = document.querySelector("#btnLoadPosts");
  let viewButton = document.querySelector("#btnViewPost");
  let postsSelectElement = document.querySelector("#posts");
  let titleElement = document.querySelector("#post-title");
  let postBodyElement = document.querySelector("#post-body");
  let postCommentsElement = document.querySelector("#post-comments");

  let response = await fetch(`${baseURL}posts`);
  let postsInfoObject = await response.json();

  loadPostsButton.addEventListener("click", () => {
    for (const [key, value] of Object.entries(postsInfoObject)) {
      let optionElement = document.createElement("option");
      optionElement.value = key;
      optionElement.textContent = value.title.toUpperCase();

      postsSelectElement.appendChild(optionElement);
    }
  });

  viewButton.addEventListener("click", async () => {
    postCommentsElement.innerHTML = "";
    let allOptions = Array.from(postsSelectElement.children);
    let selectedOption = allOptions.find((x) => x.selected === true);

    let responseComments = await fetch(`${baseURL}comments`);
    let commentsObject = await responseComments.json();

    for (const [key, value] of Object.entries(commentsObject)) {
      let liElement = document.createElement("li");

      if (value.postId === selectedOption.value) {
        liElement.textContent = value.text;
        liElement.setAttribute("id", key);
        titleElement.textContent = postsInfoObject[selectedOption.value].title.toUpperCase();
        postBodyElement.textContent = postsInfoObject[selectedOption.value].body;

        postCommentsElement.appendChild(liElement);
      }
    }
  });
}

attachEvents();

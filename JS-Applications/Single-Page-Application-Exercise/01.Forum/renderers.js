import * as requests from "./requests.js";
import * as utilities from "./utils.js";
import { renderAllComments } from "./renderComments.js";

let container = document.querySelector(".container");

function renderPost(id, title, username, createdOn, post) {
  let topicContainerDiv = document.createElement("div");
  topicContainerDiv.classList.add("topic-container");

  let topicNameWrapperDiv = document.createElement("div");
  topicNameWrapperDiv.classList.add("topic-name-wrapper");
  topicContainerDiv.appendChild(topicNameWrapperDiv);

  let topicNameDiv = document.createElement("div");
  topicNameDiv.classList.add("topic-name");
  topicNameWrapperDiv.appendChild(topicNameDiv);

  let titleAnchor = document.createElement("a");
  titleAnchor.classList.add("normal");

  let h2Element = document.createElement("h2");
  h2Element.textContent = title;
  titleAnchor.appendChild(h2Element);
  topicNameDiv.appendChild(titleAnchor);

  let metaDataDiv = document.createElement("div");
  metaDataDiv.classList.add("columns");

  let innerDiv = document.createElement("div");

  let dateParagraph = document.createElement("p");
  dateParagraph.textContent = "Date:";

  let timeElement = document.createElement("time");
  timeElement.textContent = createdOn;
  dateParagraph.appendChild(timeElement);

  let nickNameDiv = document.createElement("div");
  nickNameDiv.classList.add("nick-name");

  let usernameParagraph = document.createElement("p");
  usernameParagraph.textContent = "Username:";

  let usernameSpan = document.createElement("span");
  usernameSpan.textContent = username;
  usernameParagraph.appendChild(usernameSpan);
  nickNameDiv.appendChild(usernameParagraph);

  titleAnchor.addEventListener("click", renderPostDetails);
  function renderPostDetails() {
    requests.getTopic(id);
    container.innerHTML = `
    <!-- theme content  -->
    <div class="theme-content">
        <!-- theme-title  -->
        <div class="theme-title">
            <div class="theme-name-wrapper">
                <div class="theme-name">
                    <h2>${title}</h2>
                </div>
            </div>
        </div>
    <div class="comment">
    <div class="header">
        <img src="./static/profile.png" alt="avatar">
        <p><span>${username}</span> posted on <time>${createdOn}</time></p>
        <p class="post-content">${post}</p>
    </div>
</div>
<div class="answer-comment">
<p><span>currentUser</span> comment:</p>
<div class="answer">
    <form>
        <textarea name="postText" id="comment" cols="30" rows="10" required></textarea>
        <div>
            <label for="username">Username <span class="red">*</span></label>
            <input type="text" name="username" id="username required">
        </div>
        <button>Post</button>
    </form>
</div>
</div>`;

    let commentForm = container.querySelector("form");

    commentForm.addEventListener("submit", (ev) => {
      ev.preventDefault();
      requests.postComment(commentForm, id);
      commentForm.reset();
      renderAllComments(id);
    });
    renderAllComments(id);
  }

  innerDiv.appendChild(dateParagraph);
  innerDiv.appendChild(nickNameDiv);
  metaDataDiv.appendChild(innerDiv);
  topicNameDiv.appendChild(metaDataDiv);

  return topicContainerDiv;
}

function renderHomePage() {
  let mainElement = document.createElement("main");

  let mainDiv = document.createElement("div");
  mainDiv.classList.add("new-topic-border");

  let headerDiv = document.createElement("div");
  headerDiv.classList.add("header-background");

  let spanElement = document.createElement("span");
  spanElement.textContent = "New Topic";

  headerDiv.appendChild(spanElement);
  mainDiv.appendChild(headerDiv);

  let form = document.createElement("form");

  let titleDiv = document.createElement("div");
  titleDiv.classList.add("new-topic-title");

  let titleLabel = document.createElement("label");
  titleLabel.setAttribute("for", "topicName");
  titleLabel.textContent = "Title";

  let titleSpan = document.createElement("span");
  titleSpan.classList.add("red");
  titleSpan.textContent = "*";
  titleLabel.appendChild(titleSpan);

  let titleInput = document.createElement("input");
  titleInput.setAttribute("type", "text");
  titleInput.setAttribute("name", "topicName");
  titleInput.setAttribute("id", "topicName");
  titleInput.setAttribute("required", "true");

  titleDiv.appendChild(titleLabel);
  titleDiv.appendChild(titleInput);

  let usernameDiv = document.createElement("div");
  usernameDiv.classList.add("new-topic-title");

  let usernameLabel = document.createElement("label");
  usernameLabel.setAttribute("for", "username");
  usernameLabel.textContent = "Username";

  let usernameSpan = document.createElement("span");
  usernameSpan.classList.add("red");
  usernameSpan.textContent = "*";
  usernameLabel.appendChild(usernameSpan);

  let usernameInput = document.createElement("input");
  usernameInput.setAttribute("type", "text");
  usernameInput.setAttribute("name", "username");
  usernameInput.setAttribute("id", "username");
  usernameInput.setAttribute("required", "true");

  usernameDiv.appendChild(usernameLabel);
  usernameDiv.appendChild(usernameInput);

  let postContentDiv = document.createElement("div");
  postContentDiv.classList.add("new-topic-content");

  let postContentLabel = document.createElement("label");
  postContentLabel.setAttribute("for", "postText");
  postContentLabel.textContent = "Post";

  let postContentSpan = document.createElement("span");
  postContentSpan.classList.add("red");
  postContentSpan.textContent = "*";
  postContentLabel.appendChild(postContentSpan);

  let postContentTextarea = document.createElement("textarea");
  postContentTextarea.setAttribute("type", "text");
  postContentTextarea.setAttribute("name", "postText");
  postContentTextarea.setAttribute("id", "postText");
  postContentTextarea.setAttribute("rows", "8");
  postContentTextarea.classList.add("height");
  postContentTextarea.setAttribute("required", "true");

  postContentDiv.appendChild(postContentLabel);
  postContentDiv.appendChild(postContentTextarea);

  let buttonsDiv = document.createElement("div");
  buttonsDiv.classList.add("new-topic-buttons");

  let postButton = document.createElement("button");
  postButton.classList.add("public");
  postButton.textContent = "Post";

  let cancelButton = document.createElement("button");
  cancelButton.classList.add("cancel");
  cancelButton.textContent = "Cancel";

  buttonsDiv.appendChild(cancelButton);
  buttonsDiv.appendChild(postButton);

  form.appendChild(titleDiv);
  form.appendChild(usernameDiv);
  form.appendChild(postContentDiv);
  form.appendChild(buttonsDiv);

  form.addEventListener("submit", async (ev) => {
    ev.preventDefault();

    if (ev.submitter.outerText === "Cancel") {
      form.reset();
      return;
    }
    let response = await requests.postTopic(form);

    if (response.ok) {
      let data = await requests.getAllTopics();
      utilities.appendTopic(data);
    } else {
      alert("Error!");
    }
    form.reset();
  });

  let topicContainer = document.createElement("div");
  topicContainer.classList.add("topic-container");

  mainDiv.appendChild(form);
  mainElement.appendChild(mainDiv);
  container.replaceChildren(mainElement);
  container.appendChild(topicContainer);
}

export { renderPost, renderHomePage };

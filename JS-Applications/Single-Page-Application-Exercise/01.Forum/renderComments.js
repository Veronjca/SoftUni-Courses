import * as requests from "./requests.js";

async function renderAllComments(id) {
  let commentsContainer = document.querySelector(".comment");
  let children = Array.from(commentsContainer.children);
  children.forEach((x, index) => { 
      if(index !== 0){
          x.remove();
      }
  });
  
  let allCommentsData = await requests.getAllComments();

  for (const [, value] of Object.entries(allCommentsData)) {
    if (value.postId == id) {
      commentsContainer.innerHTML += `  <div id="user-comment">
        <div class="topic-name-wrapper">
            <div class="topic-name">
                <p><strong>${value.username}</strong> commented on <time>${value.createdOn}</time></p>
                <div class="post-content">
                    <p>${value.postText}</p>
                </div>
            </div>
        </div>
    </div>`;
    }
  }
}

export { renderAllComments };

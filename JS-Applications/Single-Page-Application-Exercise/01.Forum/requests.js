let baseURL = "http://localhost:3030/jsonstore/collections/myboard/";

async function postTopic(form) {
  let formData = new FormData(form);
  let title = formData.get("topicName");
  let username = formData.get("username");
  let post = formData.get("postText");
  let date = new Date();
  let createdOn = date.toISOString();

  return await fetch(baseURL + "posts", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ title, username, post, createdOn }),
  });
}

async function postComment(form, id) {
  let formData = new FormData(form);
  let postText = formData.get("postText");
  let username = formData.get("username");
  let postId = id;
  let date = new Date();
  let createdOn = `${date.toLocaleDateString()}, ${date.toLocaleTimeString()}`;

  await fetch(baseURL + 'comments', {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ postText, username, createdOn, postId}),
  });
}

async function getAllTopics() {
  let response = await fetch(baseURL + "posts");
  let data = await response.json();
  return data;
}

async function getAllComments() {
  let response = await fetch(baseURL + "comments");
  let data = await response.json();
  return data;
}

async function getTopic(id) {
  let response = await fetch(`${baseURL}/posts/${id}`);
  let data = await response.json();
  return data;
}

export { postTopic, getAllTopics, getTopic, postComment, getAllComments };

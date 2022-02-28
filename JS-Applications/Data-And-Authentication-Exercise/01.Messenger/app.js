function attachEvents() {
  let messagesTextArea = document.querySelector("#messages");
  let submitButton = document.querySelector("#submit");
  let refreshButton = document.querySelector("#refresh");
  let authorInputElement = document.querySelector('[name="author"]');
  let messageInputElement = document.querySelector('[name="content"]');
  let baseUrl = "http://localhost:3030/jsonstore/messenger";

  submitButton.addEventListener("click", async () => {
    let author = authorInputElement.value.trim();
    let message = messageInputElement.value;

    authorInputElement.value = '';
    messageInputElement.value = '';

    let post = {
        author, 
        content: message
    };

    await fetch(baseUrl, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(post),
    })
  });

  refreshButton.addEventListener('click', async () => {
      messagesTextArea.textContent = '';
      let request = await fetch(baseUrl);
      let content = await request.json();

      for (const [, value] of Object.entries(content)) {
          messagesTextArea.textContent += `${value.author}: ${value.content}\n`;
      }
      messagesTextArea.textContent.trimEnd();
  })
}

attachEvents();

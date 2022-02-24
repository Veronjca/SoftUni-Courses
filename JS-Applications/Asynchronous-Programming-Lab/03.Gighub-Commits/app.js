function loadCommits() {
  let username = document.querySelector("#username").value;
  let repo = document.querySelector("#repo").value;
  let ulElement = document.querySelector("#commits");

  fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
    .then((response) => {
      if (response.ok === false) {
        throw new Error(response.status);
      }

      return response.json();
    })
    .then(responseHandler)
    .catch(errorHandler);

  function responseHandler(data) {
    ulElement.innerHTML = "";
    data.forEach((element) => {
      let liElement = document.createElement("li");
      liElement.textContent = `${element.commit.author.name}: ${element.commit.message}`;

      ulElement.appendChild(liElement);
    });
  }

  function errorHandler(error) {
    ulElement.innerHTML = "";
    let liElement = document.createElement("li");
    liElement.textContent = `Error: ${error.message} (Not Found)`;

    ulElement.appendChild(liElement);
  }
}

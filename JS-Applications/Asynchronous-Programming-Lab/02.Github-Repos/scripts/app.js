function loadRepos() {
  let username = document.querySelector("#username").value;
  let ulElement = document.querySelector("#repos");

  fetch(`https://api.github.com/users/${username}/repos`)
    .then((response) => {
      if (response.ok === false) {
        throw new Error(response.status);
      }
      return response.json();
    })
    .then(handleResponse)
    .catch(errorHandler);

  function handleResponse(data) {
    ulElement.innerHTML = "";
    data.forEach((repo) => {
      let currentLiElement = document.createElement("li");

      let curretnAnkerElement = document.createElement("a");
      curretnAnkerElement.href = repo.html_url;
      curretnAnkerElement.textContent = repo.full_name;

      currentLiElement.appendChild(curretnAnkerElement);
      ulElement.appendChild(currentLiElement);
    });
  }

  function errorHandler(error){
	ulElement.innerHTML = "";
	ulElement.textContent = `Error occured! Status code: ${error.message}`;
  }
}

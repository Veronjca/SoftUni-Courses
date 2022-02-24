function loadRepos() {
  let divElement = document.querySelector("#res");
  let url = "https://api.github.com/users/testnakov/repos";
  let request = new XMLHttpRequest();
  request.open("GET", url, true);


  request.addEventListener("readystatechange", () => {
     if(request.readyState === 4){
      divElement.textContent = request.responseText;
     }
  });

  request.send();
}

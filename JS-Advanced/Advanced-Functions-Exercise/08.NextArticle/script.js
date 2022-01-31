function getArticleGenerator(input) {
  let articles = input;
  let content = document.querySelector("#content");
  function showNext() {
    if (articles.length > 0) {
      let articleElement = document.createElement("article");
      articleElement.textContent = articles.shift();
      content.appendChild(articleElement);
    }
  }
  return showNext;
}

function solve() {
  let postsSectionElement = document.querySelectorAll("section")[1];
  let authorInputElement = document.querySelector("#creator");
  let titleInputElement = document.querySelector("#title");
  let categoryInputElement = document.querySelector("#category");
  let contentInputElement = document.querySelector("#content");
  let orderedListElement = document.querySelector(".archive-section").children[1];
  let createButton = document.querySelector("form").lastChild.previousSibling;

  createButton.addEventListener("click", (ev) => {
    ev.preventDefault();

    let author = authorInputElement.value;
    let title = titleInputElement.value;
    let content = contentInputElement.value;
    let category = categoryInputElement.value;

    authorInputElement.value = "";
    titleInputElement.value = "";
    contentInputElement.value = "";
    categoryInputElement.value = "";

    let articleElement = document.createElement("article");

    let h1Element = document.createElement("h1");
    h1Element.textContent = title;

    let firstParagraphElement = document.createElement("p");
    firstParagraphElement.textContent = "Category:";

    let categoryStrongElement = document.createElement("strong");
    categoryStrongElement.textContent = category;

    firstParagraphElement.appendChild(categoryStrongElement);

    let secondParagraphElement = document.createElement("p");
    secondParagraphElement.textContent = "Creator:";

    let creatorStrongElement = document.createElement("strong");
    creatorStrongElement.textContent = author;

    secondParagraphElement.appendChild(creatorStrongElement);

    let thirdParagraphElement = document.createElement("p");
    thirdParagraphElement.textContent = content;

    let divElement = document.createElement("div");
    divElement.classList.add("buttons");

    let deleteButton = document.createElement("button");
    deleteButton.classList.add("btn");
    deleteButton.classList.add("delete");
    deleteButton.textContent = "Delete";

    let archiveButton = document.createElement("button");
    archiveButton.classList.add("btn");
    archiveButton.classList.add("archive");
    archiveButton.textContent = "Archive";

    divElement.appendChild(deleteButton);
    divElement.appendChild(archiveButton);

    articleElement.appendChild(h1Element);
    articleElement.appendChild(firstParagraphElement);
    articleElement.appendChild(secondParagraphElement);
    articleElement.appendChild(thirdParagraphElement);
    articleElement.appendChild(divElement);
    postsSectionElement.appendChild(articleElement);

    archiveButton.addEventListener("click", () => {
      let liElement = document.createElement("li");
      liElement.textContent = title;
      articleElement.remove();

      orderedListElement.appendChild(liElement);
      let elements = Array.from(orderedListElement.children);
      elements.sort((a, b) => a.textContent.localeCompare(b.textContent));
      orderedListElement.innerHTML = "";
      for (let i = 0; i < elements.length; i++) {
        orderedListElement.appendChild(elements[i]);
      }
    });

    deleteButton.addEventListener("click", () => {
      articleElement.remove();
    });
  });
}

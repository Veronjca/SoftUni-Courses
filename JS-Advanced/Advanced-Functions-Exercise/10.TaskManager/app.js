function solve() {
  let addButton = document
    .querySelector("#add")
    .addEventListener("click", addTask);
  let sectionElements = document.querySelectorAll("section");

  function addTask(ev) {
    ev.preventDefault();
    let inputFields = ev.currentTarget.parentNode.querySelectorAll("input");
    let task = inputFields[0].value;
    let description = ev.currentTarget.parentNode.querySelector("textarea").value;
    let dueDate = inputFields[1].value;
    if (task && description && dueDate) {
      let openSection = sectionElements[1];
      let parentDivElement = openSection.children[1];
      let articleElement = document.createElement("article");
      let h3Element = document.createElement("h3");
      let firstParagraph = document.createElement("p");
      let secondParagraph = document.createElement("p");
      let childDivElement = document.createElement("div");
      let firstButton = document.createElement("button");
      let secondButton = document.createElement("button");

      h3Element.textContent = task;
      firstParagraph.textContent = `Description: ${description}`;
      secondParagraph.textContent = `Due Date: ${dueDate}`;
      childDivElement.classList.add("flex");
      firstButton.textContent = "Start";
      firstButton.classList.add("green");
      secondButton.textContent = "Delete";
      secondButton.classList.add("red");

      articleElement.appendChild(h3Element);
      articleElement.appendChild(firstParagraph);
      articleElement.appendChild(secondParagraph);
      childDivElement.appendChild(firstButton);
      childDivElement.appendChild(secondButton);
      articleElement.appendChild(childDivElement);
      parentDivElement.appendChild(articleElement);

      firstButton.addEventListener("click", startTask);
      secondButton.addEventListener("click", removeTask);

      function removeTask() {
        articleElement.remove();
      }
      function startTask() {
        let inprogressSection = sectionElements[2];
        let divElement = inprogressSection.querySelector("#in-progress");
        let buttons = Array.from(articleElement.querySelectorAll("button"));

        buttons[0].classList.remove("green");
        buttons[0].classList.add("red");
        buttons[0].textContent = "Delete";
        buttons[1].classList.remove("red");
        buttons[1].classList.add("orange");
        buttons[1].textContent = "Finish";
        divElement.appendChild(articleElement);

        buttons[1].addEventListener("click", finishTask);
        buttons[0].addEventListener('click', deleteTask);

        function deleteTask(){
            articleElement.remove();
        }

        function finishTask() {
          buttons.map((x) => x.remove());
          childDivElement.remove();
          let completedSection = sectionElements[3].children[1];
          completedSection.appendChild(articleElement);
        }
      }
    }
    inputFields[0].value = "";
    ev.currentTarget.parentNode.querySelector("textarea").value = "";
    inputFields[1].value = "";
  }
}

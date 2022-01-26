function addItem() {
  let inputElement = document.getElementById("newItemText");
  let inputText = inputElement.value;
  inputElement.value = "";

  let list = document.getElementById("items");

  let liElement = document.createElement("li");
  liElement.textContent = inputText;
  let linkElement = document.createElement("a");
  linkElement.textContent = "[Delete]";
  linkElement.href = "#";

  liElement.appendChild(linkElement);
  list.appendChild(liElement);
  linkElement.addEventListener('click', removeElement);

  function removeElement(ev) {
    ev.currentTarget.parentNode.remove();
  }
}

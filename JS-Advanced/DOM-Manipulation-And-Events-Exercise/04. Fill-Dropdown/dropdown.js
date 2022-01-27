function addItem() {
  let selectElement = document.querySelector("#menu");
  let opitonElement = document.createElement("option");
  let inputValueElement = document.querySelector("#newItemValue");
  let inputTextElement = document.querySelector("#newItemText");
  opitonElement.value = inputValueElement.value;
  opitonElement.textContent = inputTextElement.value;
  selectElement.appendChild(opitonElement);
  inputValueElement.value = "";
  inputTextElement.value = "";
}

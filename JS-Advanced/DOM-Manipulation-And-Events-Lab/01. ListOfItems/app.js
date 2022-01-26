function addItem() {
    let inputText = document.getElementById('newItemText').value;
    let list = document.getElementById('items');
    let liElement = document.createElement('li');
    liElement.textContent = inputText;
    list.appendChild(liElement);
}
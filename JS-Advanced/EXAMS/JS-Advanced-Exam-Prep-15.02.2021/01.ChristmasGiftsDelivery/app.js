function solution() {
  let sectionElements = document.querySelectorAll(".card");
  let listOfGiftsUlElement = sectionElements[1].children[1];
  let sentGiftsUlElement = sectionElements[2].children[1];
  let discardedGiftsUlElement = sectionElements[3].children[1];
  let addGiftInputElement = document.querySelector('input[type="text"]');
  let addGiftButton = addGiftInputElement.nextElementSibling;

  addGiftButton.addEventListener("click", (ev) => {
    ev.preventDefault();
    let giftName = addGiftInputElement.value;

    addGiftInputElement.value = "";

    let liElement = document.createElement("li");
    liElement.classList.add("gift");
    liElement.textContent = giftName;

    let sendButton = document.createElement("button");
    sendButton.setAttribute("id", "sendButton");
    sendButton.textContent = "Send";

    let discardButton = document.createElement("button");
    discardButton.setAttribute("id", "discardButton");
    discardButton.textContent = "Discard";

    liElement.appendChild(sendButton);
    liElement.appendChild(discardButton);

    listOfGiftsUlElement.appendChild(liElement);
    let elements = Array.from(listOfGiftsUlElement.children);
    elements.sort((a, b) => a.textContent.localeCompare(b.textContent));

    listOfGiftsUlElement.innerHTML = "";
    elements.forEach((e) => {
        listOfGiftsUlElement.appendChild(e);
    });

    sendButton.addEventListener('click', () => {
        sendButton.remove();
        discardButton.remove();
        sentGiftsUlElement.appendChild(liElement);
    })

    discardButton.addEventListener('click', () => {
        sendButton.remove();
        discardButton.remove();
        discardedGiftsUlElement.appendChild(liElement);
    })
  });
}

function solve() {
    let buttons = document.querySelectorAll('button');
  let onScreenButton = buttons[0]
    .addEventListener("click", addMovie);
    let clearButton = buttons[1]
    .addEventListener('click', clear);
  let inputFields = document.querySelectorAll("input");
  let archiveSection = document.querySelector("#archive").children[1];
  let moviesSection = document.querySelector("#movies").children[1];

  function addMovie(ev) {
    let name = inputFields[0].value;
    let hall = inputFields[1].value;
    let ticketPrice = inputFields[2].value;
    ev.preventDefault();

    if ((name && hall && Number(ticketPrice))) {
      let liElement = document.createElement("li");
      let spanElement = document.createElement("span");
      let hallStrongElement = document.createElement("strong");
      let divElement = document.createElement("div");
      let priceStrongElement = document.createElement("strong");
      let inputElement = document.createElement("input");
      let buttonElement = document.createElement("button");

      spanElement.textContent = name;
      hallStrongElement.textContent = `Hall: ${hall}`;
      priceStrongElement.textContent = Number(ticketPrice).toFixed(2);
      inputElement.placeholder = "Tickets Sold";
      buttonElement.textContent = "Archive";

      liElement.appendChild(spanElement);
      liElement.appendChild(hallStrongElement);

      divElement.appendChild(priceStrongElement);
      divElement.appendChild(inputElement);
      divElement.appendChild(buttonElement);

      liElement.appendChild(divElement);
      moviesSection.appendChild(liElement);
      buttonElement.addEventListener("click", archive);
    }
      inputFields[0].value = '';
      inputFields[1].value = '';
      inputFields[2].value = '';

  
      function archive(ev) {
        if (Number(ev.currentTarget.parentNode.children[1].value) >= 0 && ev.currentTarget.parentNode.children[1].value) {
          let liElement = document.createElement("li");
          let spanElement = document.createElement("span");
          let strongElement = document.createElement("strong");
          let buttonElement = document.createElement("button");

          let liParent = ev.currentTarget.parentNode.parentNode;
          let divParent = ev.currentTarget.parentNode;

          let name = liParent.children[0].textContent;
          let price = Number(divParent.children[0].textContent);
          let amount = Number(divParent.children[1].value);
          let totalPrice = price * amount;

          spanElement.textContent = name;
          strongElement.textContent = `Total amount: ${totalPrice.toFixed(2)}`;
          buttonElement.textContent = "Delete";

          liElement.appendChild(spanElement);
          liElement.appendChild(strongElement);
          liElement.appendChild(buttonElement);
          archiveSection.appendChild(liElement);
          liParent.remove();

          buttonElement.addEventListener("click", removeMovie);

          function removeMovie(ev) {
            ev.currentTarget.parentNode.remove();
          }
        }
      }
    
  }

  function clear(ev){
      let liElements = Array.from(ev.currentTarget.parentNode.querySelectorAll('li'));
      liElements.map(x => x.remove());
  }
}

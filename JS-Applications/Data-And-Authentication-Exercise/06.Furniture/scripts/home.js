import {logout} from "./logout.js";
import {createFurniture} from "./createFurniture.js";

let theadElement = document.querySelector("thead");
let baseURL = "http://localhost:3030/data/furniture";
let tbodyElement = document.querySelector("tbody");
let logoutElement = document.querySelector("#guest").querySelectorAll("a")[1];
let loginElement = document.querySelector("#guest").querySelectorAll("a")[0];

window.addEventListener("load", async () => {
  let response = await fetch(baseURL);
  let responseBody = await response.json();

  if (responseBody.length === 0) {
    theadElement.innerHTML = "No items to show.";
  } else {
    let trElement = document.createElement("tr");

    let imageTh = document.createElement("th");
    imageTh.textContent = "Image";

    let nameTh = document.createElement("th");
    nameTh.textContent = "Name";

    let priceTh = document.createElement("th");
    priceTh.textContent = "Price";

    let decFactorTh = document.createElement("th");
    decFactorTh.textContent = "Decoration factor";

    let markTh = document.createElement("th");
    markTh.textContent = "Mark";

    trElement.appendChild(imageTh);
    trElement.appendChild(nameTh);
    trElement.appendChild(priceTh);
    trElement.appendChild(decFactorTh);
    trElement.appendChild(markTh);

    theadElement.appendChild(trElement);

    for (const item of responseBody) {
     createFurniture(item, tbodyElement);
    }
  }

  if (!sessionStorage.user) {
    let checkboxElements = tbodyElement.querySelectorAll("input[type=checkbox]");
    checkboxElements.forEach((x) => {
      x.disabled = true;
    });
    logoutElement.classList.add("hide");
    loginElement.classList.remove('hide');
  } else {
    logoutElement.classList.remove("hide");
    loginElement.classList.add('hide');

    logoutElement.addEventListener('click', () => {
        logout();
    })
  }
});



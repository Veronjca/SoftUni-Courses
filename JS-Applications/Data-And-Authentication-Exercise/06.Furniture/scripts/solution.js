import { logout } from "./logout.js";
import {createFurniture} from "./createFurniture.js";

let logoutBtn = document.querySelector("#logoutBtn");
let buyBtn = document.querySelector("#buyBtn");
let allOrdersButton = document.querySelector("#allOrdersBtn");
let tbodyElement = document.querySelector("tbody");
let createForm = document.querySelector("#create-form");
let totalPriceSpan = document.querySelector('#totalPrice');
let boughtFurnitureSpan = document.querySelector('#boughtFurniture');


let baseURL = "http://localhost:3030/data/";
let user = JSON.parse(sessionStorage.user);

logoutBtn.addEventListener("click", () => {
  logout();
});

createForm.addEventListener("submit", async (ev) => {
  ev.preventDefault();

  let formData = new FormData(createForm);
  let img = formData.get("img");
  let name = formData.get("name");
  let price = formData.get("price");
  let decFactor = formData.get("factor");
  let item = {img, name, price, decFactor};

  let response = await fetch(`${baseURL}furniture`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "X-authorization": user.accessToken,
    },
    body: JSON.stringify(item),
  });

  if (response.ok) {
   createFurniture(item, tbodyElement);
  }
  createForm.reset();
});

buyBtn.addEventListener("click", () => {
  let checkboxes = tbodyElement.querySelectorAll("input[type=checkbox]");
  checkboxes.forEach(async (x) => {
    if (x.checked) {
      let trElement = x.parentNode.parentNode;
      let name = trElement.children[1].children[0].textContent;
      let price = trElement.children[2].children[0].textContent;

      await fetch(`${baseURL}/orders`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          "X-authorization": user.accessToken,
        },
        body: JSON.stringify({ name, price }),
      });
    }
  });

  checkboxes.forEach(x => x.checked = false);
});

allOrdersButton.addEventListener('click', async () => {
    let response = await fetch(`${baseURL}/orders`);
    let responseBody = await response.json();

    let boughtItems = [];
    responseBody.forEach(x =>{
        boughtItems.push(x.name);
    })

    let price = responseBody.reduce((a,b) => a + Number(b.price), 0);
    totalPriceSpan.textContent = `${price} $`;
    boughtFurnitureSpan.textContent = boughtItems.join(', ');
})

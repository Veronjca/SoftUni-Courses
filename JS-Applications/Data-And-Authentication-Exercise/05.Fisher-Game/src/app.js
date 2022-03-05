import { logout } from "./logout.js";

let baseURL = "http://localhost:3030/data/catches";

let homeElement = document.querySelector("#home");
let navigationElement = document.querySelector("nav");
let span = document.querySelector("span");
let loginElement = document.querySelector("#login");
let registerElement = document.querySelector("#register");
let logoutElement = document.querySelector("#logout");
let loadButton = document.querySelector(".load");
let addButton = document.querySelector(".add");
let catchesContainer = document.querySelector("#catches");
let addForm = document.querySelector('#addForm');

if (sessionStorage.user) {
  let currentUser = JSON.parse(sessionStorage.user);
  span.textContent = currentUser.username;
  loginElement.style.display = "none";
  registerElement.style.display = "none";
  logoutElement.style.display = "inline";
  addButton.disabled = false;
}

window.onload = () => {
  let ankerElements = navigationElement.querySelectorAll("a");
  ankerElements.forEach((x) => {
    x.classList.remove("active");
  });

  homeElement.classList.add("active");
};

logoutElement.addEventListener("click", async (ev) => {
  ev.preventDefault();
  logout();
});

addForm.addEventListener('submit', async (ev) =>{
    ev.preventDefault();
    let formData = new FormData(addForm);
    let angler = formData.get("angler");
    let weight = formData.get('weight');
    let species = formData.get('species');
    let location = formData.get('location');
    let bait = formData.get('bait');
    let captureTime = formData.get('captureTime');

    let record = {
        angler,
        weight,
        species,
        location,
        bait,
        captureTime,
    }

   let response = await fetch(baseURL, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
            "X-Authorization": JSON.parse(sessionStorage.user).accessToken,
        },
        body: JSON.stringify(record),
    })

    let responseBody = await response.json();
    createCatchRecord(responseBody);
    addForm.reset();
})

loadButton.addEventListener("click", async () => {
  catchesContainer.innerHTML = "";
  let response = await fetch(baseURL);
  let catches = await response.json();

  for (const currentCatch of catches) {
      createCatchRecord(currentCatch);
  }

  let divs = catchesContainer.querySelectorAll("div");

  let currentUser = "";

  if(sessionStorage.user){
    currentUser = JSON.parse(sessionStorage.user);
  }


  divs.forEach((x) => {
    if (x.id !== currentUser._id || !currentUser) {
      let children = Array.from(x.children);
      children.forEach((x) => {
        x.disabled = true;
      });
    }
  });
});

function createCatchRecord(currentCatch){
    let mainDiv = document.createElement("div");
    mainDiv.classList.add("catch");
    mainDiv.setAttribute("id", currentCatch._ownerId);

    let anglerLabel = document.createElement("label");
    anglerLabel.textContent = "Angler";

    let anglerInput = document.createElement("input");
    anglerInput.setAttribute("type", "text");
    anglerInput.classList.add("angler");
    anglerInput.value = currentCatch.angler;

    let weightLabel = document.createElement("label");
    weightLabel.textContent = "Weight";

    let weightInput = document.createElement("input");
    weightInput.setAttribute("type", "text");
    weightInput.classList.add("weight");
    weightInput.value = currentCatch.weight;

    let speciesLabel = document.createElement("label");
    speciesLabel.textContent = "Species";

    let speciesInput = document.createElement("input");
    speciesInput.setAttribute("type", "text");
    speciesInput.classList.add("species");
    speciesInput.value = currentCatch.species;

    let locationLabel = document.createElement("label");
    locationLabel.textContent = "Location";

    let locationInput = document.createElement("input");
    locationInput.setAttribute("type", "text");
    locationInput.classList.add("location");
    locationInput.value = currentCatch.location;

    let baitLabel = document.createElement("label");
    baitLabel.textContent = "Bait";

    let baitInput = document.createElement("input");
    baitInput.setAttribute("type", "text");
    baitInput.classList.add("bait");
    baitInput.value = currentCatch.bait;

    let captureTimeLabel = document.createElement("label");
    captureTimeLabel.textContent = "Capture Time";

    let captureTimeInput = document.createElement("input");
    captureTimeInput.setAttribute("type", "text");
    captureTimeInput.classList.add("captureTime");
    captureTimeInput.value = currentCatch.captureTime;

    let updateButton = document.createElement("button");
    updateButton.textContent = "Update";
    updateButton.classList.add("update");
    updateButton.setAttribute("data-id", currentCatch._ownerId);

    updateButton.addEventListener("click", async () => {
      let body = {
        angler: anglerInput.value,
        weight: weightInput.value,
        species: speciesInput.value,
        location: locationInput.value,
        bait: baitInput.value,
        captureTime: captureTimeInput.value,
      };
      await fetch(`${baseURL}/${currentCatch._id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          "X-Authorization": JSON.parse(sessionStorage.user).accessToken,
        },
        body: JSON.stringify(body),
      });
    });

    let deleteButton = document.createElement("button");
    deleteButton.textContent = "Delete";
    deleteButton.classList.add("delete");
    deleteButton.setAttribute("data-id", currentCatch._ownerId);
    deleteButton.addEventListener("click", async () => {
      await fetch(`${baseURL}/${currentCatch._id}`, {
        method: "DELETE",
        headers: {
            "X-Authorization": JSON.parse(sessionStorage.user).accessToken,
        }
      });

      loadButton.click();
    });

    mainDiv.appendChild(anglerLabel);
    mainDiv.appendChild(anglerInput);
    mainDiv.appendChild(weightLabel);
    mainDiv.appendChild(weightInput);
    mainDiv.appendChild(speciesLabel);
    mainDiv.appendChild(speciesInput);
    mainDiv.appendChild(locationLabel);
    mainDiv.appendChild(locationInput);
    mainDiv.appendChild(baitLabel);
    mainDiv.appendChild(baitInput);
    mainDiv.appendChild(captureTimeLabel);
    mainDiv.appendChild(captureTimeInput);
    mainDiv.appendChild(updateButton);
    mainDiv.appendChild(deleteButton);

    catchesContainer.appendChild(mainDiv);
}
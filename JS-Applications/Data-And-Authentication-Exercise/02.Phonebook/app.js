function attachEvents() {
  let baseUrl = "http://localhost:3030/jsonstore/phonebook";

  let loadButton = document.querySelector("#btnLoad");
  let createButton = document.querySelector("#btnCreate");
  let list = document.querySelector("#phonebook");
  let personInputElement = document.querySelector("#person");
  let phoneInputElement = document.querySelector("#phone");

  loadButton.addEventListener("click", async () => {
    list.innerHTML = "";
    let request = await fetch(baseUrl);
    let phonebookInfо = await request.json();

    for (const [key, value] of Object.entries(phonebookInfо)) {
      let liElement = document.createElement("li");
      liElement.setAttribute('id', key);
      liElement.textContent = `${value.person}: ${value.phone} `;

      let deleteButton = document.createElement("button");
      deleteButton.textContent = "Delete";

      deleteButton.addEventListener('click', async () => {
          await fetch(`${baseUrl}/${liElement.id}`,{
              method: 'delete',
          })
          loadButton.click();
      })

      liElement.appendChild(deleteButton);
      list.appendChild(liElement);
    }
  });

  createButton.addEventListener("click", async () => {
    let person = personInputElement.value.trim();
    let phone = phoneInputElement.value.trim();

    personInputElement.value = "";
    phoneInputElement.value = "";

    let record = {person, phone};

    await fetch(baseUrl, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(record),
    })
    loadButton.click();
  });
}

attachEvents();

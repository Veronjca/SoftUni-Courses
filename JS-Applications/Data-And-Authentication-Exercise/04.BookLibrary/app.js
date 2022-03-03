function solve() {
  let baseURL = "http://localhost:3030/jsonstore/collections/books";

  let loadAllBooksButton = document.querySelector("#loadBooks");
  let body = document.querySelector("tbody");
  let form = document.querySelector("form");
  let button = form.querySelector("button");
  let titleInputElement = form.querySelector('[name="title"');
  let authorInputElement = form.querySelector('[name="author"]');
  let h3Element = form.querySelector("h3");

  form.addEventListener("submit", async (ev) => {
    ev.preventDefault();

    let formData = new FormData(form);
    let title = formData.get("title");
    let author = formData.get("author");
    let record = { title, author };

    if (button.textContent === "Submit") {
      if (!title || !author) {
        alert("Invalid data!");
        return;
      }

      await fetch(baseURL, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(record),
      }); 
    } else {
      h3Element.textContent = 'FORM';
      button.textContent = 'Submit';

      await fetch(`${baseURL}/${button.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(record),
      });
    }

    form.reset();
    loadAllBooksButton.click();
  });

  loadAllBooksButton.addEventListener("click", async (ev) => {
    ev.preventDefault();
    body.innerHTML = '';

    let response = await fetch(baseURL);
    let booksCollection = await response.json();

    for (const [key, value] of Object.entries(booksCollection)) {
      createBookRecord(value.title, value.author, key);
    }
  });

  async function createBookRecord(title, author, id) {
    let row = document.createElement("tr");
    row.setAttribute('id', id);

    let bookNameData = document.createElement("td");
    bookNameData.textContent = title;

    let authorData = document.createElement("td");
    authorData.textContent = author;

    let actionsData = document.createElement("td");

    let editButton = document.createElement("button");
    editButton.textContent = "Edit";

    let deleteButton = document.createElement("button");
    deleteButton.textContent = "Delete";

    editButton.addEventListener("click", () => {
      row.remove();
 
      h3Element.textContent = "EditFORM";

      button.textContent = "Save";
      button.setAttribute("id", id);

      titleInputElement.value = title;
      authorInputElement.value = author;
    });

    deleteButton.addEventListener("click", async () =>{
        await fetch(`${baseURL}/${row.id}`, {
            method: "DELETE",
        })
        row.remove();
    });

    actionsData.appendChild(editButton);
    actionsData.appendChild(deleteButton);

    row.appendChild(bookNameData);
    row.appendChild(authorData);
    row.appendChild(actionsData);
    body.appendChild(row);
  }
}

let result = solve();

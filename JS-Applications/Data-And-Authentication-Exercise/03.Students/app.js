window.onload = solve;

function solve() {
  let baseUrl = "http://localhost:3030/jsonstore/collections/students";

  let form = document.querySelector("form");
  let tbody = document.querySelector("tbody");

  form.addEventListener("submit", async (ev) => {
    ev.preventDefault();
    let formData = new FormData(form);
    tbody.innerHTML = "";

    let firstName = formData.get("firstName").trim();
    let lastName = formData.get("lastName").trim();
    let facultyNumber = formData.get("facultyNumber").trim();
    let grade = formData.get("grade").trim();

    if (!firstName || !lastName || !facultyNumber || !grade) {
      form.reset();
      alert("Error: Invalid credentials!");
      return;
    }

    if (/^[A-Za-z]+$/.test(firstName) || /^[A-Za-z]+$/.test(lastName) || /^[0-9]+$/.test(facultyNumber)|| !Number(grade)) {
      form.reset();
      alert("Error: Invalid credentials!");
      return;
    }

    let student = {
      firstName,
      lastName,
      facultyNumber,
      grade,
    };

    await fetch(baseUrl, {
      method: "post",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(student),
    });

    let request = await fetch(baseUrl);
    let studentsInfo = await request.json();

    for (const [, value] of Object.entries(studentsInfo)) {
      let trElement = document.createElement("tr");

      let tdFirstName = document.createElement("td");
      tdFirstName.textContent = value.firstName;

      let tdLastName = document.createElement("td");
      tdLastName.textContent = value.lastName;

      let tdFacilityNumber = document.createElement("td");
      tdFacilityNumber.textContent = value.facultyNumber;

      let tdGrade = document.createElement("td");
      tdGrade.textContent = value.grade;

      trElement.appendChild(tdFirstName);
      trElement.appendChild(tdLastName);
      trElement.appendChild(tdFacilityNumber);
      trElement.appendChild(tdGrade);

      tbody.appendChild(trElement);
      form.reset();
    }
  });
}

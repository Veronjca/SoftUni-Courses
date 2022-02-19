function solve() {
  let firstNameInputElement = document.querySelector("#fname");
  let lastNameInputElement = document.querySelector("#lname");
  let emailInputElement = document.querySelector("#email");
  let birthDateInputElement = document.querySelector("#birth");
  let positionInputElement = document.querySelector("#position");
  let salaryInputElement = document.querySelector("#salary");
  let hireWorkerButton = document.querySelector("#add-worker");
  let tbodyElement = document.querySelector('#tbody');
  let sumSpanElement = document.querySelector('#sum');

  hireWorkerButton.addEventListener("click", (ev) => {
    ev.preventDefault();

    let firstName = firstNameInputElement.value;
    let lastName = lastNameInputElement.value;
    let email = emailInputElement.value;
    let birthDate = birthDateInputElement.value;
    let position = positionInputElement.value;
    let salary = salaryInputElement.value;

    firstNameInputElement.value = "";
    lastNameInputElement.value = "";
    emailInputElement.value = "";
    birthDateInputElement.value = "";
    positionInputElement.value = "";
    salaryInputElement.value = "";

    if(firstName && lastName && email && birthDate && position && salary){

        let trElement = document.createElement('tr');

        let firstNameTd = document.createElement('td');
        firstNameTd.textContent = firstName;

        let lastNameTd = document.createElement('td');
        lastNameTd.textContent = lastName;

        let birthDateTd = document.createElement('td');
        birthDateTd.textContent = birthDate;

        let emailTd = document.createElement('td');
        emailTd.textContent = email;

        let positionTd = document.createElement('td');
        positionTd.textContent = position;

        let salaryTd = document.createElement('td');
        salaryTd.textContent = salary;

        let actionsTd = document.createElement('td');

        let firedButton = document.createElement('button');
        firedButton.classList.add('fired');
        firedButton.textContent = 'Fired';

        let editButton = document.createElement('button');
        editButton.classList.add('edit');
        editButton.textContent = 'Edit';

        actionsTd.appendChild(firedButton);
        actionsTd.appendChild(editButton);

        trElement.appendChild(firstNameTd);
        trElement.appendChild(lastNameTd);
        trElement.appendChild(emailTd);
        trElement.appendChild(birthDateTd);
        trElement.appendChild(positionTd);
        trElement.appendChild(salaryTd);
        trElement.appendChild(actionsTd);

        tbodyElement.appendChild(trElement);

        let sum = Number(sumSpanElement.textContent) + Number(salary);
        sumSpanElement.textContent = sum.toFixed(2);

        editButton.addEventListener('click', () =>{
            firstNameInputElement.value = firstName;
            lastNameInputElement.value = lastName;
            emailInputElement.value = email;
            birthDateInputElement.value = birthDate;
            positionInputElement.value = position;
            salaryInputElement.value = salary;

            let currentSum = Number(sumSpanElement.textContent) - Number(salary);
            sumSpanElement.textContent = currentSum.toFixed(2);

            trElement.remove();
        })

        firedButton.addEventListener('click', () => {
            trElement.remove();
            let currentSum = Number(sumSpanElement.textContent) - Number(salary);
            sumSpanElement.textContent = currentSum.toFixed(2);
        })

    }
  });
}
solve();
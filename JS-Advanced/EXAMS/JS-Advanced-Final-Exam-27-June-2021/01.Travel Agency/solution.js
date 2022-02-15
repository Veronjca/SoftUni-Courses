window.addEventListener("load", solution);

function solution() {
  let fullNameInputElement = document.querySelector("#fname");
  let emailInputElement = document.querySelector("#email");
  let phoneNumberInputElement = document.querySelector("#phone");
  let addressInputElement = document.querySelector("#address");
  let postalCodeInputElement = document.querySelector("#code");
  let blockDivContainer = document.querySelector("#block");
  let ulElement = document.querySelector("#infoPreview");
  let editButton = document.querySelector("#editBTN");
  let continueButton = document.querySelector("#continueBTN");
  let submitButton = document.querySelector("#submitBTN");

  submitButton.addEventListener("click", (ev) => {
    ev.preventDefault();
    let fullName = fullNameInputElement.value;
    let email = emailInputElement.value;
    let phoneNumber = phoneNumberInputElement.value;
    let address = addressInputElement.value;
    let postalCode = postalCodeInputElement.value;

    fullNameInputElement.value = "";
    emailInputElement.value = "";
    phoneNumberInputElement.value = "";
    addressInputElement.value = "";
    postalCodeInputElement.value = "";

    if (!fullName.trim() || !email.trim() || !phoneNumber || !address || !postalCode) {
      return;
    }

    let fullNameLiElement = document.createElement("li");
    let emailLiElement = document.createElement("li");
    let phoneNumberLiElement = document.createElement("li");
    let addressLiElement = document.createElement("li");
    let postalCodeLiElement = document.createElement("li");

    fullNameLiElement.textContent = `Full Name: ${fullName}`;
    emailLiElement.textContent = `Email: ${email}`;
    phoneNumberLiElement.textContent = `Phone Number: ${phoneNumber}`;
    addressLiElement.textContent = `Address: ${address}`;
    postalCodeLiElement.textContent = `Postal Code: ${postalCode}`;

    ulElement.appendChild(fullNameLiElement);
    ulElement.appendChild(emailLiElement);
    ulElement.appendChild(phoneNumberLiElement);
    ulElement.appendChild(addressLiElement);
    ulElement.appendChild(postalCodeLiElement);
    submitButton.disabled = true;
    editButton.disabled = false;
    continueButton.disabled = false;

    editButton.addEventListener("click", (ev) => {
      ev.preventDefault();
      fullNameInputElement.value = fullName;
      emailInputElement.value = email;
      phoneNumberInputElement.value = phoneNumber;
      addressInputElement.value = address;
      postalCodeInputElement.value = postalCode;

      ulElement.innerHTML = "";
      editButton.disabled = true;
      continueButton.disabled = true;
      submitButton.disabled = false;
    });

    continueButton.addEventListener("click", () => {
      blockDivContainer.innerHTML = "";

      let h3Element = document.createElement("h3");
      h3Element.textContent = "Thank you for your reservation!";
      blockDivContainer.appendChild(h3Element);
    });
  });
}

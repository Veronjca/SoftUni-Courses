function validate() {
  let companyNumberField = document.getElementById("companyNumber");
  let validField = document.getElementById("valid");
  let usernameField = document.getElementById("username");
  let emailField = document.getElementById("email");
  let passwordField = document.getElementById("password");
  let confirmPasswordField = document.getElementById("confirm-password");
  let isCompanyCheckbox = document.getElementById("company");

  isCompanyCheckbox.addEventListener("change", (ev) => {
    if (ev.currentTarget.checked) {
      document.getElementById("companyInfo").style.display = "block";
    } else {
      document.getElementById("companyInfo").style.display = "none";
    }
  });
  let submitButton = document.getElementById("submit");
  submitButton.type = "button";
  submitButton.addEventListener("click", validateEmail);

  let usernameRegEx = /^[A-Za-z0-9]{3,20}$/g;
  let passwordRegEx = /^[\w]{5,15}$/g;
  let emailRegEx = /^[^@.]+\@[^@]*\.[^@]*$/g;

  function validateEmail(ev) {
    ev.preventDefault();

    let username = usernameField.value;
    let email = emailField.value;
    let password = passwordField.value;
    let confirmPassword = confirmPasswordField.value;
    let flag = true;
    let companyNumber = undefined;

    if (isCompanyCheckbox.checked) {
      companyNumber = Number(companyNumberField.value);
    }

    if (!usernameRegEx.test(username)) {
      usernameField.style.borderColor = "red";
      flag = false;
    } else {
      usernameField.style.border = "none";
    }
    if (!emailRegEx.test(email)) {
      emailField.style.borderColor = "red";
      flag = false;
    } else {
      emailField.style.border = "none";
    }
    if (!passwordRegEx.test(password) || passwordRegEx.test(confirmPassword) || password !== confirmPassword) {
      passwordField.style.borderColor = "red";
      confirmPasswordField.style.borderColor = "red";
      flag = false;
    } else {
      passwordField.style.border = "none";
      confirmPasswordField.style.border = "none";
    }
    if (companyNumber !== undefined && (companyNumber < 1000 || companyNumber > 9999)) {
      companyNumberField.style.borderColor = "red";
      flag = false;
    } else {
      companyNumberField.style.border = "none";
    }

    if (flag === true) {
      validField.style.display = "block";
    } else {
      validField.style.display = "none";
    }
  }
}

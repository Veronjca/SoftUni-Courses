function validate() {
  let inputField = document.querySelector("#email");
  let inputElement = inputField.value;
  let myRegEx = /^[a-z]+@[a-z]+\.[a-z]+$/;
  inputField.addEventListener("change", validateEmail);

  function validateEmail(ev) {
    if (!myRegEx.test(ev.currentTarget.value)) {
        ev.currentTarget.classList.add('error');
    }else{
        ev.currentTarget.classList.remove('error');
    }
  }
}

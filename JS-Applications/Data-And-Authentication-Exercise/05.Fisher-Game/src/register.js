let baseURL = "http://localhost:3030/users/register";
let form = document.querySelector("form");
let registerElement = document.querySelector("#register");
let navigationElement = document.querySelector("nav");

window.onload = () => {
  let ankerElements = navigationElement.querySelectorAll("a");
  ankerElements.forEach((x) => {
    x.classList.remove("active");
  });
  registerElement.classList.add("active");
};

form.addEventListener("submit", async (ev) => {
  ev.preventDefault();

  let formData = new FormData(form);
  let email = formData.get("email");
  let password = formData.get("password");
  let repeatedPassword = formData.get("rePass");
  let username = formData.get('username');

  if (password !== repeatedPassword) {
    alert("Passwords dont't match!");
    form.reset();
    return;
  }

  let response = await fetch(baseURL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ email, password, username }),
  });

  let responseBody = await response.json();

  if(!response.ok){
      alert('Invalid email!');
  }else{
      sessionStorage.setItem('user', JSON.stringify(responseBody));
      location.href = "./index.html";
  }
  form.reset();
});

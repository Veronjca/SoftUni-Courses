const navElement = document.querySelector("nav");

let userAnchors = navElement.querySelectorAll('#user');
let guestAnchors = navElement.querySelectorAll('#guest');

function displayCorrectNavigation() {
  if (sessionStorage.user) {
    userAnchors.forEach((x) => (x.style.display = "inline-block"));
    guestAnchors.forEach((x) => (x.style.display = "none"));
  } else {
    userAnchors.forEach((x) => (x.style.display = "none"));
    guestAnchors.forEach((x) => (x.style.display = "inline-block"));
  }
}

export {displayCorrectNavigation};

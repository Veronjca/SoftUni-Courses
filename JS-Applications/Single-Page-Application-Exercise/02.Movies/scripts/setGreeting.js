let greetingAnchor = document.querySelector(".welcome");

function setGreeting() {
    if(sessionStorage.user){
        let user = JSON.parse(sessionStorage.user);
        greetingAnchor.innerText = `Welcome, ${user.email}`;
    }
}

export { setGreeting };

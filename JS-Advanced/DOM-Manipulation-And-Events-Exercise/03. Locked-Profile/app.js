function lockedProfile() {
  let buttons = Array.from(document.getElementsByTagName("button"))
  .forEach((x) => x.addEventListener("click", onClick));

  function onClick(ev) {
    let conteiner = ev.currentTarget.previousElementSibling;
    let parent = ev.currentTarget.parentNode;
    let unlockElement = parent.querySelector('input[value="unlock"]');
    if(unlockElement.checked && ev.currentTarget.textContent == 'Show more'){
        conteiner.style.display = 'block';
        ev.currentTarget.textContent = 'Hide it';
    }else if(unlockElement.checked && ev.currentTarget.textContent == 'Hide it'){
        conteiner.style.display = 'none';
        ev.currentTarget.textContent = 'Show more';
    }     
  }
}

async function lockedProfile() {
  let response = await fetch("http://localhost:3030/jsonstore/advanced/profiles");
  let profilesObject = await response.json();

  let mainElement = document.querySelector("#main");
  mainElement.innerHTML = "";

  for (const [, value] of Object.entries(profilesObject)) {
    mainElement.innerHTML += `<div class="profile">
<img src="./iconProfile2.png" class="userIcon" />
<label>Lock</label>
<input type="radio" name="user1Locked" value="lock" checked>
<label>Unlock</label>
<input type="radio" name="user1Locked" value="unlock"><br>
<hr>
<label>Username</label>
<input type="text" name="user1Username" value="${value.username}" disabled readonly />
<div class="hiddenInfo">
    <hr>
    <label>Email:</label>
    <input type="email" name="user1Email" value="${value.email}" disabled readonly />
    <label>Age:</label>
    <input type="email" name="user1Age" value="${value.age}" disabled readonly />
</div>

<button>Show more</button>
</div>`;
  }

  let buttons = Array.from(mainElement.querySelectorAll("button"));
  buttons.forEach((x) => {
    x.addEventListener("click", (ev) => {
      let conteiner = ev.currentTarget.previousElementSibling;
      let parent = ev.currentTarget.parentNode;
      let unlockElement = parent.querySelector('input[value="unlock"]');

      if (unlockElement.checked && ev.currentTarget.textContent == "Show more") {
        conteiner.style.display = "inline-block";
        let children = Array.from(conteiner.children);
        children.forEach((x) => (x.style.display = "block"));
        ev.currentTarget.textContent = "Hide it";
      } else if (unlockElement.checked && ev.currentTarget.textContent == "Hide it") {
        conteiner.style.display = "none";
        ev.currentTarget.textContent = "Show more";
      }
    });
  });
}

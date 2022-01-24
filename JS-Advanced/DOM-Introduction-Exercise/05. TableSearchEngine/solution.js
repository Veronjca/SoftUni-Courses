function solve() {
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    let rows = Array.from(
      document
        .querySelector(".container")
        .querySelector("tbody")
        .querySelectorAll("tr")
    );
    let value = document.querySelector('#searchField').value;
    rows.forEach((x) => {
         x.className = '';
     });
    rows.forEach((x) => {
     if(x.textContent.includes(value)){
        x.className = 'select';
     }
    });
  }
}

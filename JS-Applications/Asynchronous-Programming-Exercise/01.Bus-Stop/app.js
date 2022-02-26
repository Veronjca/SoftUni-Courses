window.onload = getInfo;

function getInfo() {
  let id = document.querySelector("#stopId");
  let divStopNameElement = document.querySelector("#stopName");
  let ulElement = document.querySelector("#buses");
  let checkButton = document.querySelector("#submit");

    checkButton.addEventListener("click", async () => {
        ulElement.innerHTML = "";
        try {
            let request = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${id.value}`);
            let busInfo = await request.json();
              
            let busStopName = busInfo.name;
            divStopNameElement.textContent = busStopName;
      
            for (const [key, value] of Object.entries(busInfo.buses)) {
              let currentLi = document.createElement("li");
              currentLi.textContent = `Bus ${key} arrives in ${value} minutes`;
              ulElement.appendChild(currentLi);
            }
        } catch (error) {
            divStopNameElement.textContent = 'Error';
        }
    
    });
}

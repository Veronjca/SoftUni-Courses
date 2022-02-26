function solve() {
  let stopID = "depot";
  let baseURL = "http://localhost:3030/jsonstore/bus/schedule/";
  let infoSpanElement = document.querySelector(".info");
  let departButton = document.querySelector("#depart");
  let arriveButton = document.querySelector("#arrive");

  async function depart() {
      try {
        let request = await fetch(`${baseURL}${stopID}`);
        let currentStop = await request.json();
    
        infoSpanElement.textContent = `Next stop ${currentStop.name}`;
        stopID = currentStop.next;
        departButton.disabled = true;
        arriveButton.disabled = false;
      } catch (error) {
        departButton.disabled = true;
        arriveButton.disabled = true;
        infoSpanElement.textContent = 'Error';
      }
    
  }

  function arrive() {
    let stopName = infoSpanElement.textContent.split(" ").slice(2);
    infoSpanElement.textContent = `Arriving at ${stopName.join(' ')}`;
    arriveButton.disabled = true;
    departButton.disabled = false;
  }

  return {
    depart,
    arrive,
  };
}

let result = solve();

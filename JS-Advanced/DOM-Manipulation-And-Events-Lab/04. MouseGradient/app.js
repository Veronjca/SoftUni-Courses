function attachGradientEvents() {
  let hoverBoardElement = document.getElementById("gradient");
  hoverBoardElement.addEventListener("mousemove", getPercentage);
  let result = 0;
  function getPercentage(ev) {
    result = Math.floor((ev.offsetX / hoverBoardElement.clientWidth ) * 100);
    document.getElementById("result").textContent = `${result}%`;
    console.log(ev);
  } 
}

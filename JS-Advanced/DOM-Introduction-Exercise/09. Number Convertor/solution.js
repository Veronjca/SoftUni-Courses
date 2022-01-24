function solve() {
  document.querySelector("button").addEventListener("click", onClick);

  let option = document.createElement("option");
  option.value = "binary";
  option.innerHTML = "Binary";
  let secondOption = document.createElement("option");
  secondOption.value = "hexadecimal";
  secondOption.innerHTML = "Hexadecimal";
  let element = document.getElementById("selectMenuTo");
  element.appendChild(option);
  element.appendChild(secondOption);
  function onClick() {
    let number = Number(document.getElementById("input").value);
    if (element.value === "binary") {    
      document.getElementById("result").value = number.toString(2);
    }else if(element.value === 'hexadecimal'){
        document.getElementById("result").value = number.toString(16).toString().toUpperCase();
    }
  }
}

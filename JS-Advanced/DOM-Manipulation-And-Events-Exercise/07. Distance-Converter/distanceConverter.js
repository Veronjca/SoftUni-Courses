function attachEventsListeners() {
  let convertButton = document.querySelector("#convert");
  convertButton.addEventListener("click", convert);

  function convert(ev) {
    let convertFrom = ev.currentTarget.previousElementSibling.value;
    let convertTo = ev.currentTarget.parentNode.nextElementSibling.querySelector("#outputUnits").value;
    let inputDistance = Number(document.getElementById("inputDistance").value);
    let resultElement = document.getElementById("outputDistance");

    if (convertFrom == "km") {
        inputDistance *= 1000;
    }else if(convertFrom =='cm'){
        inputDistance *= 0.01;
    }else if(convertFrom == 'mm'){
        inputDistance *= 0.001;
    }else if(convertFrom == 'mi'){
        inputDistance *= 1609.34;
    }else if(convertFrom == 'yrd'){
        inputDistance *= 0.9144;
    }else if(convertFrom == 'ft'){
        inputDistance *= 0.3048;
    }else if(convertFrom == 'in'){
        inputDistance *= 0.0254;
    }

    if (convertTo == "km") {
        inputDistance /= 1000;
    }else if(convertTo =='cm'){
        inputDistance /= 0.01;
    }else if(convertTo == 'mm'){
        inputDistance /= 0.001;
    }else if(convertTo == 'mi'){
        inputDistance /= 1609.34;
    }else if(convertTo == 'yrd'){
        inputDistance /= 0.9144;
    }else if(convertTo == 'ft'){
        inputDistance /= 0.3048;
    }else if(convertTo == 'in'){
        inputDistance /= 0.0254;
    }
    resultElement.value = inputDistance;   
  }
}

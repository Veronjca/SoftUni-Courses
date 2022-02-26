function attachEvents() {
  let baseURL = "http://localhost:3030/jsonstore/forecaster/";
  let getWeatherButton = document.querySelector("#submit");
  let locationInputElement = document.querySelector("#location");
  let forecastDiv = document.querySelector("#forecast");
  let currentConditionsDivElement = document.querySelector("#current");
  let threeDayForecastDivElement = document.querySelector("#upcoming");

  function getSymbol(condition) {
    switch (condition) {
      case "Sunny":
        return "&#x2600";
      case "Partly sunny":
        return "&#x26C5";
      case "Overcast":
        return "&#x2601";
      case "Rain":
        return "&#x2614;";
    }
  }
  getWeatherButton.addEventListener("click", async () => {
    try {
      let location = locationInputElement.value;

      currentConditionsDivElement.innerHTML = '<div class="label">Current conditions</div>';
      threeDayForecastDivElement.innerHTML = '<div class="label">Three-day forecast</div>';

      let divs = Array.from(forecastDiv.children);
      divs.forEach((x) => (x.style.display = 'block'));

      let paragraphs = Array.from(forecastDiv.querySelectorAll('p'));
      paragraphs.forEach(x => {
          x.remove();
      })

      let response = await fetch(`${baseURL}locations`);
      let locations = await response.json();

      let neededLocation = locations.find((x) => x.name === location);

      let response2 = await fetch(`${baseURL}today/${neededLocation.code}`);
      let forecastForToday = await response2.json();

      let response3 = await fetch(`${baseURL}upcoming/${neededLocation.code}`);
      let upcomingForecastInfo = await response3.json();

      forecastDiv.style.display = "inline";

      let weatherSymbol = getSymbol(forecastForToday.forecast.condition);
      let degreesSymbol = "&#176";

      let forecastDivElement = document.createElement("div");
      forecastDivElement.classList.add("forecasts");

      let condtionSpanElement = document.createElement("span");
      condtionSpanElement.classList.add("condition");
      condtionSpanElement.classList.add("symbol");
      condtionSpanElement.innerHTML = weatherSymbol;

      forecastDivElement.appendChild(condtionSpanElement);

      let forecastDataSpanElement = document.createElement("span");
      forecastDataSpanElement.classList.add("condition");

      let locationSpanElement = document.createElement("span");
      locationSpanElement.classList.add("forecast-data");
      locationSpanElement.textContent = forecastForToday.name;

      let degreesSpanElement = document.createElement("span");
      degreesSpanElement.classList.add("forecast-data");
      degreesSpanElement.innerHTML = `${forecastForToday.forecast.low}${degreesSymbol}/${forecastForToday.forecast.high}${degreesSymbol}`;

      let weatherSpanElement = document.createElement("span");
      weatherSpanElement.classList.add("forecast-data");
      weatherSpanElement.textContent = forecastForToday.forecast.condition;

      forecastDataSpanElement.appendChild(locationSpanElement);
      forecastDataSpanElement.appendChild(degreesSpanElement);
      forecastDataSpanElement.appendChild(weatherSpanElement);

      forecastDivElement.appendChild(forecastDataSpanElement);
      currentConditionsDivElement.appendChild(forecastDivElement);

      let upcomingForecastInfoDiv = document.createElement("div");
      upcomingForecastInfoDiv.classList.add("forecast-info");

      upcomingForecastInfo.forecast.forEach((x) => {
        weatherSymbol = getSymbol(x.condition);

        let upcomingSpan = document.createElement("span");
        upcomingSpan.classList.add("upcoming");

        let weatherSymbolSpan = document.createElement("span");
        weatherSymbolSpan.classList.add("symbol");
        weatherSymbolSpan.innerHTML = weatherSymbol;

        let degreesSpan = document.createElement("span");
        degreesSpan.classList.add("forecast-data");
        degreesSpan.innerHTML = `${x.low}${degreesSymbol}/${x.high}${degreesSymbol}`;

        let conditonSpan = document.createElement("span");
        conditonSpan.classList.add("forecast-data");
        conditonSpan.textContent = x.condition;

        upcomingSpan.appendChild(weatherSymbolSpan);
        upcomingSpan.appendChild(degreesSpan);
        upcomingSpan.appendChild(conditonSpan);

        upcomingForecastInfoDiv.appendChild(upcomingSpan);
      });

      threeDayForecastDivElement.appendChild(upcomingForecastInfoDiv);
    } catch (error) {
      forecastDiv.style.display = "inline";
      let divElements = Array.from(forecastDiv.children);
      divElements.forEach((x) => (x.style.display = 'none'));

      let paragraph = document.createElement('p');
      paragraph.textContent = 'Error';

      forecastDiv.appendChild(paragraph);
    }
  });
}

attachEvents();

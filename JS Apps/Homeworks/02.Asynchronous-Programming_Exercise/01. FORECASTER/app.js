function attachEvents() {
  const elements = {
    inputField: document.getElementById("location"),
    button: document.getElementById("submit"),
    forecastDiv: document.getElementById("forecast"),
    currentDiv: document.getElementById("current"),
    upcomingDiv: document.getElementById("upcoming")
  };

  const symbols = {
    sunny: "☀",
    partlySunny: "⛅",
    overcast: "☁",
    rain: "☂",
    degrees: "°"
  };

  //   const urls = {
  //     base: "https://judgetests.firebaseio.com/locations.json",
  //     today: "https://judgetests.firebaseio.com/forecast/today/{code}.json"
  //   };

  elements.button.addEventListener("click", loadWeatherInfo);

  const urlBase = "https://judgetests.firebaseio.com/locations.json";

  function loadWeatherInfo() {
    fetch(urlBase)
      .then(handler)
      .then(loadLocationWeatherInfo);
  }

  function loadLocationWeatherInfo(data) {
    let location = data.filter(o => o.name === elements.inputField.value)[0];

    const urlToday = `https://judgetests.firebaseio.com/forecast/today/${location.code}.json`;

    fetch(urlToday)
      .then(handler)
      .then(data => showTodayWeatherInfo(data, location.code));
  }

  function showTodayWeatherInfo(data, code) {
    elements.forecastDiv.style.display = "block";
    // elements.currentDiv.textContent = "";
    // elements.upcomingDiv.textContent = "";

    const divForecast = createHTMLElement("div", "forecasts");

    const symbol = symbols[data.forecast.condition.toLowerCase()];
    const spanSymbol = createHTMLElement(
      "span",
      ["condition", "symbol"],
      symbol
    );

    const spanHolder = createHTMLElement("span", "condition");

    const spanName = createHTMLElement("span", "forecast-data", data.name);

    const degrees = `${data.forecast.low}${symbols.degrees}/${data.forecast.high}${symbols.degrees}`;
    const spanDegrees = createHTMLElement("span", "forecast-data", degrees);
    const spanCondition = createHTMLElement(
      "span",
      "forecast-data",
      data.forecast.condition
    );

    spanHolder.appendChild(spanName);
    spanHolder.appendChild(spanDegrees);
    spanHolder.appendChild(spanCondition);

    divForecast.appendChild(spanSymbol);
    divForecast.appendChild(spanHolder);

    elements.currentDiv.appendChild(divForecast);

    loadUpcomingWeatherInfo(code);
  }

  function loadUpcomingWeatherInfo(code) {
    const urlUpcoming = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;
    fetch(urlUpcoming)
      .then(handler)
      .then(showUpcomingWeatherInfo);
  }

  function showUpcomingWeatherInfo(data) {
    const divForecast = createHTMLElement("div", "forecasts-info");

    data.forecast.forEach(o => {
      const spanHolder = createHTMLElement("span", "upcoming");

      const symbol =
        symbols[o.condition.toLowerCase()] ||
        symbols["partlySunny"];
      const spanSymbol = createHTMLElement("span", "symbol", symbol);

      const degrees = `${o.low}${symbols.degrees}/${o.high}${symbols.degrees}`;
      const spanDegrees = createHTMLElement("span", "forecast-data", degrees);

      const spanCondition = createHTMLElement(
        "span",
        "forecast-data",
        o.condition
      );

      spanHolder.appendChild(spanSymbol);
      spanHolder.appendChild(spanDegrees);
      spanHolder.appendChild(spanCondition);
      divForecast.appendChild(spanHolder);

      elements.upcomingDiv.appendChild(divForecast);
    });
    // elements.currentDiv.textContent = "";
    // elements.upcomingDiv.textContent = "";
  }

  // function appendChildrenToParent(children, parent) {
  //   children.forEach(child => parent.appendChild(child));
  // }

  function createHTMLElement(tagName, className, textContent) {
    let currentElement = document.createElement(tagName);

    if (typeof className === "string") {
      currentElement.classList.add(className);
    } else if (typeof className === "object") {
      currentElement.classList.add(...className);
    }

    if (textContent) {
      currentElement.textContent = textContent;
    }

    return currentElement;
  }

  function handler(response) {
    if (!response.ok) {
      throw new Error(
        JSON.stringify({
          status: response.status,
          statusText: response.statusText
        })
      );
    }
    return response.json();
  }
}

attachEvents();

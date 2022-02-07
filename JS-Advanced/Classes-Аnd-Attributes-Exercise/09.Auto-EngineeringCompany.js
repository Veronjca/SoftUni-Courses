function solve(input) {
  let cars = {};

  for (const carInfo of input) {
    let [brand, model, producedCars] = carInfo.split(" | ");
    if (!cars.hasOwnProperty(brand)) {
      cars[brand] = {};
    }

    if (cars[brand].hasOwnProperty(model)) {
      cars[brand][model] += Number(producedCars);
    } else {
      cars[brand][model] = Number(producedCars);
    }
  }

  for (const brand in cars) {
    console.log(brand);
    for (const [model, producedCars] of Object.entries(cars[brand])) {
      console.log(`###${model} -> ${cars[brand][model]}`);
    }
  }
}

solve([
  "Audi | Q7 | 1000",
  "Audi | Q6 | 100",
  "BMW | X5 | 1000",
  "BMW | X6 | 100",
  "Citroen | C4 | 123",
  "Volga | GAZ-24 | 1000000",
  "Lada | Niva | 1000000",
  "Lada | Jigula | 1000000",
  "Citroen | C4 | 22",
  "Citroen | C5 | 10",
]);

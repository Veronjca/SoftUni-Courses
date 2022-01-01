function fruit(fruitType, weight, pricePerKilogram){

    let kilo = weight / 1000;
    let moneyNeeded = kilo * pricePerKilogram;
    console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${kilo.toFixed(2)} kilograms ${fruitType}.`);
}

fruit('orange', 2500, 1.80);
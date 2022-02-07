function solve(input) {
  let juices = {};
  let bottles = {};

  for (const juice of input) {
    let [currentJuice, quantity] = juice.split(" => ");
    if (!juices.hasOwnProperty(currentJuice)) {
      juices[currentJuice] = 0;
    }
    juices[currentJuice] += Number(quantity);
    let leftover = juices[currentJuice] % 1000;
    let totalBottles = (juices[currentJuice] - leftover) / 1000;

    if (totalBottles >= 1) {
      if (!bottles.hasOwnProperty(currentJuice)) {
        bottles[currentJuice] = 0;
      }
      bottles[currentJuice] += totalBottles;    
    }
    juices[currentJuice] = leftover;
  }
  for (const [juice, amount] of Object.entries(bottles)) {
    console.log(`${juice} => ${amount}`);
  }
}

solve(["Kiwi => 234", "Pear => 2345", "Watermelon => 3456", "Kiwi => 4567", "Pear => 5678", "Watermelon => 6789"]);

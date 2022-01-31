function solution() {
  let ingredients = {
    protein: 0,
    carbohydrate: 0,
    fat: 0,
    flavour: 0,
  };
  let recipes = {
    apple: {
      carbohydrate: 1,
      flavour: 2,
    },
    lemonade: {
      carbohydrate: 10,
      flavour: 20,
    },
    burger: {
      carbohydrate: 5,
      fat: 7,
      flavour: 3,
    },
    eggs: {
      protein: 5,
      fat: 1,
      flavour: 1,
    },
    turkey: {
      protein: 10,
      carbohydrate: 10,
      fat: 10,
      flavour: 10,
    },
  };

  function solve(input) {
    let commands = input.split(" ");
    let command = commands[0];

    if (command === "restock") {
      let microelement = commands[1];
      let quantity = Number(commands[2]);
      ingredients[microelement] += quantity;
      return "Success";
    } else if (command === "prepare") {
      let recipe = commands[1];
      let quantity = Number(commands[2]);

      for (const [ingredient, amount] of Object.entries(recipes[recipe])) {
        let neededQuantity = quantity * amount;
        if (ingredients[ingredient] < neededQuantity) {
          return `Error: not enough ${ingredient} in stock`;
        }
        ingredients[ingredient] -= neededQuantity;
      }
      return "Success";
    } else if (command === "report") {
      let result = [];
      for (const [ingredient, amount] of Object.entries(ingredients)) {
        result.push(`${ingredient}=${amount}`);
      }
      return result.join(" ");
    }
  }
  return solve;
}

let manager = solution();
console.log(manager("restock flavour 50"));
console.log(manager("prepare lemonade 4"));
console.log(manager("restock carbohydrate 10"));
console.log(manager("restock flavour 10"));
console.log(manager("prepare apple 1"));
console.log(manager("restock fat 10"));
console.log(manager("prepare burger 1"));
console.log(manager("report"));

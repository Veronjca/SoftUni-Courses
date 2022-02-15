class Restaurant {
  constructor(budgetMoney) {
    this.budgetMoney = Number(budgetMoney);
    this.menu = {};
    this.stockProducts = {};
    this.history = [];
  }

  loadProducts(products) {
    for (const productInfo of products) {
      let [name, quantity, price] = productInfo.split(" ");

      if (!this.stockProducts.hasOwnProperty(name) && this.budgetMoney >= Number(price)) {
        this.budgetMoney -= Number(price);
        this.stockProducts[name] = Number(quantity);
        this.history.push(`Successfully loaded ${quantity} ${name}`);
      } else if (this.budgetMoney >= Number(price)) {
        this.budgetMoney -= Number(price);
        this.stockProducts[name] += Number(quantity);
        this.history.push(`Successfully loaded ${quantity} ${name}`);
      } else {
        this.history.push(`There was not enough money to load ${quantity} ${name}`);
      }
    }

    return this.history.join("\n");
  }

  addToMenu(meal, neededProducts, price) {
    if (!this.menu.hasOwnProperty(meal)) {
      this.menu[meal] = Object.assign({}, { products: neededProducts, price: price });
    } else {
      return `The ${meal} is already in the our menu, try something different.`;
    }
    let allMeals = Object.entries(this.menu);

    if (allMeals.length === 1) {
      return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
    } else {
      return `Great idea! Now with the ${meal} we have ${allMeals.length} meals in the menu, other ideas?`;
    }
  }

  showTheMenu() {
    let allMeals = Object.entries(this.menu);
    if (allMeals.length === 0) {
      return "Our menu is not ready yet, please come later...";
    }

    let result = "";
    for (const [key, value] of allMeals) {
      result += `${key} - $ ${value.price}\n`;
    }

    return result.trimEnd();
  }

  makeTheOrder(meal) {
    if (!this.menu.hasOwnProperty(meal)) {
      return `There is not ${meal} yet in our menu, do you want to order something else?`;
    }
    let mealProducts = this.menu[meal].products;

    for (const product of mealProducts) {
      let [name, quantity] = product.split(" ");
      if (!this.stockProducts.hasOwnProperty(name) || this.stockProducts[name] < quantity) {
        return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
      }
    }
    for (const product of mealProducts) {
        let [name, quantity] = product.split(" ");
        this.stockProducts[name]-= quantity;
      }

    this.budgetMoney += this.menu[meal].price;
    return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
  }
}


let test = new Restaurant(1000);
console.log(test.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));
console.log(test.budgetMoney);

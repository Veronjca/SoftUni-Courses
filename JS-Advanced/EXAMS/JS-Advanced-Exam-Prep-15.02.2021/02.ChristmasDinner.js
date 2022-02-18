class ChristmasDinner {
  constructor(budget) {
    this.budget = budget;
    this.dishes = [];
    this.products = [];
    this.guests = {};
  }
get budget(){
    return this._budget;
}
  set budget(value) {
    if (value < 0) {
      throw new Error("The budget cannot be a negative number");
    }

    this._budget = value;
  }

  shopping(product) {
    let [type, price] = product;

    if (price > this._budget) {
      throw new Error("Not enough money to buy this product");
    }

    this.budget -= price;
    this.products.push(type);
    return `You have successfully bought ${type}!`;
  }

  recipes(recipe) {
    for (const product of recipe.productsList) {
      if (!this.products.includes(product)) {
        throw new Error("We do not have this product");
      }
    }

    this.dishes.push(recipe);
    return `${recipe.recipeName} has been successfully cooked!`;
  }

  inviteGuests(name, dish) {
    if (!this.dishes.some(x => x.recipeName === dish)) {
      throw new Error("We do not have this dish");
    }

    if(this.guests.hasOwnProperty(name)){
        throw new Error("This guest has already been invited");
    }

    this.guests[name] = dish;
    return `You have successfully invited ${name}!`;
  }

  showAttendance(){
      let result = '';

      for (const [key, value] of Object.entries(this.guests)) {
          let currentDish = this.dishes.find(x => x.recipeName === value);
          result += `${key} will eat ${value}, which consists of ${currentDish.productsList.join(', ')}\n`;
      }

      return result.trimEnd();
  }
}
let dinner = new ChristmasDinner(300);

dinner.budget = 200;
console.log(dinner.budget);

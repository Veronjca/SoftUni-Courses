class VegetableStore {
  constructor(owner, location) {
    this.owner = owner;
    this.location = location;
    this.availableProducts = [];
  }

  loadingVegetables(vegetables) {
    let types = new Set();

    for (const vegatebleInfo of vegetables) {
      let [type, quantity, price] = vegatebleInfo.split(" ");
      types.add(type);

      if (this.availableProducts.some(x => x.type === type)) {
        let vegi = this.availableProducts.find(x => x.type === type);
        vegi.quantity += Number(quantity);

        if (Number(price) > vegi.price) {
          vegi.price = Number(price);
        }
      } else {
        let currentVegi = {
          type,
          quantity: Number(quantity),
          price: Number(price),
        };
        this.availableProducts.push(currentVegi);
      }
    }

    return `Successfully added ${Array.from(types).join(", ")}`;
  }

  buyingVegetables(selectedProducts) {
    let totalPrice = 0;
    for (const product of selectedProducts) {
      let [type, quantity] = product.split(" ");

      if (!this.availableProducts.some(x => x.type === type)) {
        throw new Error(`${type} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
      }

      let vegi = this.availableProducts.find(x => x.type === type);

      if (vegi.quantity < Number(quantity)) {
        throw new Error(
          `The quantity ${quantity} for the vegetable ${type} is not available in the store, your current bill is $${totalPrice.toFixed(
            2
          )}.`
        );
      }

      totalPrice += Number(quantity) * vegi.price;
      vegi.quantity -= Number(quantity);
    }

    return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
  }

  rottingVegetable(type, quantity) {
    if (!this.availableProducts.some(x => x.type === type)) {
      throw new Error(`${type} is not available in the store.`);
    }

    let vegi = this.availableProducts.find(x => x.type === type);

    if(vegi.quantity <= Number(quantity)){
        vegi.quantity = 0;
        return `The entire quantity of the ${type} has been removed.`;
    }

    vegi.quantity -= Number(quantity);
    return `Some quantity of the ${type} has been removed.`;
  }

  revision (){
      let result = "Available vegetables:\n";
      this.availableProducts.sort((a,b) => a.price - b.price);

      this.availableProducts.forEach(x => {
          result += `${x.type}-${x.quantity}-$${x.price}\n`;
      })

      result += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;
      return result;
  }
}

let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());

function solve(input) {
  let result = [];

  for (const item of input) {
    let [product, price] = item.split(" : ");
    result.push(Object.assign({}, { product, price: Number(price) }));
  }
  result.sort((x, y) => x.product.localeCompare(y.product));
  let letter = null;
  for (const item of result) {
    if (item.product[0] !== letter) {
      letter = item.product[0];
      console.log(letter);
    }
    console.log(`  ${item.product}: ${item.price}`)
  }
}
solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);

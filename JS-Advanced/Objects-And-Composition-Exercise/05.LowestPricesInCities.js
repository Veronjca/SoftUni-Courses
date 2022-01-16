function solve(input){
    let result = [];
    for (const item of input) {
        let [town, product, price] = item.split(' | ');
        if(!result.some(x => x.product === product)){
            result.push(Object.assign({}, {town, product, price: Number(price)}));
        }
        let objToCompare = result.find(x => x.product === product);
        if(price < objToCompare.price){
            objToCompare['town'] = town;
            objToCompare['price'] = price;
        }       
    }

    for (const item of result) {
        console.log(`${item.product} -> ${item.price} (${item.town})`);       
    }
}

solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']);
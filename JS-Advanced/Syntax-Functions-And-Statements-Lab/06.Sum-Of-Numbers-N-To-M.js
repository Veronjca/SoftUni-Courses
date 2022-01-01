function getSum(a, b){
    let start = Number(a);
    let end = Number(b);
    let sum = 0;
    for (let index = start; index <= end; index++) {
        
        sum += index;
    }
    return sum;
};

console.log(getSum('-8', '20' ));
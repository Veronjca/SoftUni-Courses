function getOdds(array){
    let result = [];
    for (let i = 1; i < array.length; i+=2) {
       
        result.push(array[i] * 2);
    }
    let line = '';
    result.reverse();
    result.forEach(element => {
        line += `${element} `;
    });
    return line;
}

console.log(getOdds([10, 15, 20, 25]));
console.log(getOdds([3, 0, 10, 4, 7, 3]));
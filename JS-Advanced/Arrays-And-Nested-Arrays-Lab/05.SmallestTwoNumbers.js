function solve(array){
    let result  = '';
    array.sort((a,b) => a - b);
    result = `${array[0]} ${array[1]}`;
    console.log(result);
};

solve([30, 15, 50, 5]);
solve([3, 0, 10, 4, 7, 3]);
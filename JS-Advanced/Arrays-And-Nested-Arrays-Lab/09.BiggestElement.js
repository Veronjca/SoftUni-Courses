function getBiggestNumber(matrix){
    let number = Number.MIN_SAFE_INTEGER;
    for (let i = 0; i < matrix.length; i++) {
       let num = Math.max(...matrix[i]);
       if(num > number){
           number = num;
       }       
    }

    return number;
};

console.log(getBiggestNumber([[20, 50, 10],
    [8, 33, 145]]));
    console.log(getBiggestNumber([[3, 5, 7, 12],
        [-1, 4, 33, 2],
        [8, 3, 0, 4]]));
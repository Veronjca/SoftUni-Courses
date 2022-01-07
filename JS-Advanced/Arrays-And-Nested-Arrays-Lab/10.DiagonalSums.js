function getDiagonalSum(matrix){
    let primeSum = 0;
    let secondarySum = 0;

    for (let i = 0; i < matrix.length; i++) {
       for (let j = 0; j < matrix[i].length; j++) {
           
        if(i == j){
            primeSum += matrix[i][j];
        }        
       }
        secondarySum += matrix[i][matrix.length - i- 1];
    }
    let line = `${primeSum} ${secondarySum}`;
    console.log(line);
}

getDiagonalSum([[20, 40],
    [10, 60]]);
    getDiagonalSum([[3, 5, 17],
        [-1, 7, 14],
        [1, -8, 89]]);
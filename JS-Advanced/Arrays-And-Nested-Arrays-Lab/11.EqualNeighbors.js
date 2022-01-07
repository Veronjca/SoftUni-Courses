function solve (matrix){
    let counter = 0;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if(matrix[i][j+1] === matrix[i][j]){
                counter++;
            }
            if(i < matrix.length - 1){
                if(matrix[i+1][j] === matrix[i][j]){
                    counter++;
                }  
            }                                
        }       
    }
    return counter;
}

console.log(solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]));
console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]));
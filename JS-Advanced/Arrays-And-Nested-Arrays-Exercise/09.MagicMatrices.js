function magic(matrix){
    let sum = matrix[0].reduce((a,b) => a+b);
    
    for (let i = 0; i < matrix.length; i++) {
        let currentRowSum = matrix[i].reduce((a,b) => a+b);
        let currentColSum = 0;
                  
        for (let j = 0; j < matrix.length; j++) {
            currentColSum += matrix[j][i];         
        } 
        if(currentRowSum != sum || currentColSum != sum){
            return false;
        } 
    }
    
return true;
}
console.log(magic([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]));
console.log(magic([[11, 32, 45],
        [21, 0, 1],
        [21, 1, 1]]));
console.log(magic([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]));
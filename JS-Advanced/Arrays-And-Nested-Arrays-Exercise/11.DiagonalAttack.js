function solve(matrix) {
  let leftSum = 0;
  let rightSum = 0;
  let newMatrix = [];
  for (let k = 0; k < matrix.length; k++) {
      let current = matrix[k].split(' ');
      newMatrix.push(current.map(Number));     
  }

  matrix = newMatrix;

  for (let i = 0; i < matrix.length; i++) {
    for (let j = 0; j < matrix.length; j++) {
      if (i == j) {
        leftSum += matrix[i][j];
      } 
      if (i == matrix.length - 1 - j) {
        rightSum += matrix[i][j];
      }
    }
  }

  if (leftSum == rightSum) {
    for (let i = 0; i < matrix.length; i++) {
      for (let j = 0; j < matrix.length; j++) {
        if (i == matrix.length - 1 - j || i == j) {
            continue;
        }      
          matrix[i][j] = leftSum;               
      }
    }   
  }

  for (let j = 0; j < matrix.length; j++) {
    console.log(matrix[j].join(" "));
  }
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']);

solve(['1 1 1',
'1 1 1',
'1 1 0']);

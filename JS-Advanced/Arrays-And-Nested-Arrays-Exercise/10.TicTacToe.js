function solve(moves) {
  let player = 'X';

  let board = [
    [false, false, false],
    [false, false, false],
    [false, false, false],
  ];

  for (let i = 0; i < moves.length; i++) {
    let coordinates = moves[i].split(" ");
    let row = Number(coordinates[0]);
    let col = Number(coordinates[1]);
   
    if(!isInside(row, col, board)){
      continue;
    }
   
    if (isAvailable(board, row, col)) {
      board[row][col] = player;
    } else {
      console.log("This place is already taken. Please choose another!");
      continue;
    }

    let winSymbol = winner(board);
    if (winSymbol == "X" || winSymbol == 'O') {
      console.log(`Player ${winSymbol} wins!`);
      printMatrix(board);
      return;
    }
    if(hasEmptySpaces(board) === false){
      console.log("The game ended! Nobody wins :(");
      printMatrix(board);
      return;
    }
   
    player = player === 'X' ? 'O' : 'X'; 
  }

  function isInside(row, col, board) {
    return row >= 0 && row < board.length && col >= 0 && col < board.length;
  }

  function isAvailable(board, row, col) {
    return board[row][col] === false;
  }

  function printMatrix(board){
    for (let i = 0; i < board.length; i++) {
      console.log(board[i].join("\t"));
    }
  }

  function hasEmptySpaces(board){
    return board.some(x => x.some(y => y === false));
  }

  function winner(board) {

    for (let i = 0; i < board.length; i++) {
      let first = 0;
      let second = 0;
      for (let j = 0; j < board.length; j++) {
        if (board[i][j] == "X") {
          first++;
        } else if (board[i][j] == "O") {
          second++;
        }
      }
      if (first == 3) {
        return "X";
      } else if (second == 3) {
        return "O";
      }
      first = 0;
      second = 0;
      for (let k = 0; k < board.length; k++) {
        if (board[k][i] == "X") {
          first++;
        } else if (board[k][i] == "O") {
          second++;
        }
      }
      if (first == 3) {
        return "X";
      } else if (second == 3) {
        return "O";
      }
      let firstRight = 0;
      let firstLeft = 0;
      let secondRight = 0;
      let secondLeft = 0;

      let counter = board.length - 1;
      for (let j = 0; j < board.length; j++) {
        if(board[j][j] == 'X'){
          firstLeft++;
        }else if(board[j][j] == 'O'){
          secondLeft++;
        }
        if(board[j][counter] == 'X'){
          firstRight++;
        }else if(board[j][counter] == 'O'){
          secondRight++;
        }  
        counter--;     
      }

      if(secondRight == 3 || secondLeft == 3){
        return 'O';
      }else if(firstRight == 3 || firstLeft == 3){
        return 'X';
      }
    }
  }
}

solve(["0 1",
"0 1",
"0 1",
"0 2",
"1 1",
"0 0",
"2 1"]);
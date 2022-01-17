function solve(input) {
  let numbers = [];

  for (const item of input) {
    if (Number.isInteger(item)) {
      numbers.push(item);
    } else {
      if (numbers.length <= 1) {
        console.log("Error: not enough operands!");
        return;
      }

      let second = numbers.pop();
      let first = numbers.pop();

      if (item === "+") {
        let result = first + second;
        numbers.push(result);
      } else if (item === "-") {
        let result = first - second;
        numbers.push(result);
      } else if (item === "/") {
        let result = first / second;
        numbers.push(result);
      } else if (item === "*") {
        let result = first * second;
        numbers.push(result);
      }
    }
  }
  if (numbers.length >= 2) {
    console.log("Error: too many operands!");
    return;
  }
  console.log(numbers[0]);
}
solve([3, 4, "+"]);

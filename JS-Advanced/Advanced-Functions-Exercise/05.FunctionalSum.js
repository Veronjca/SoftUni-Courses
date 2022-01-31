function add(num) {
  let sum = num;

  function solve(num1) {
    sum += num1;
    return solve;
  }
  solve.toString = function () {
    return sum;
  };
  return solve;
}

console.log(add(1)(6)(-3).toString());

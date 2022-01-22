function calc() {
  let firstNumber = Number(document.getElementById("num1").value);
  let secondNumber = Number(document.getElementById("num2").value);
  let sum = firstNumber + secondNumber;
  document.getElementById("sum").value = sum;
}

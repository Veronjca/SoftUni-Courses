function sumTable() {
    let elements = Array.from(document.querySelectorAll('tbody tr'));
    let sum = 0;
   for (let i = 1; i < elements.length - 1; i++) {
     
       sum += Number(elements[i].lastChild.textContent);
   }
  let result = document.getElementById('sum');
  result.textContent = sum;

}
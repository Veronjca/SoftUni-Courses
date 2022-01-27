function solve() {
  let inputFields = Array.from(document.querySelectorAll("tbody tr td input"));
  let buttons = document.querySelectorAll("button");
  let resultParagraph = document.querySelector('#check p');
  let tableElement = document.querySelector('table');
  buttons[0].addEventListener("click", check);
  buttons[1].addEventListener('click', clear);

  function check() {
    let firstRow = new Set();
    let secondRow = new Set();
    let thirdRow = new Set();

    let firstColumn = new Set();
    let secondColumn = new Set();
    let thirdColumn = new Set();

    for (let i = 0; i < inputFields.length; i++) {
      if (i <= 2) {
        firstRow.add(inputFields[i].value);
      } else if (i > 2 && i <= 5) {
        secondRow.add(inputFields[i].value);
      } else if (i > 5 && i <= 8) {
        thirdRow.add(inputFields[i].value);
      }
    }

    firstColumn.add(inputFields[0].value);
    firstColumn.add(inputFields[3].value);
    firstColumn.add(inputFields[6].value);

    secondColumn.add(inputFields[1].value);
    secondColumn.add(inputFields[4].value);
    secondColumn.add(inputFields[7].value);

    thirdColumn.add(inputFields[2].value);
    thirdColumn.add(inputFields[5].value);
    thirdColumn.add(inputFields[8].value);

    if(firstRow.size == 3 && secondRow.size == 3 && thirdRow.size == 3
        && firstColumn.size == 3 && secondColumn.size == 3 && thirdColumn.size == 3){
            tableElement.style.borderWidth = '2px';
            tableElement.style.borderStyle = 'solid';
            tableElement.style.borderColor = 'green';
            resultParagraph.textContent = 'You solve it! Congratulations!';
            resultParagraph.style.color = 'green';
    }else{
        tableElement.style.borderWidth = '2px';
        tableElement.style.borderStyle = 'solid';
        tableElement.style.borderColor = 'red';
        resultParagraph.textContent = 'NOP! You are not done yet...';
        resultParagraph.style.color = 'red';
    }
  }

  function clear(){
      inputFields.forEach(x => x.value = '');
      resultParagraph.textContent = '';
      tableElement.style.borderWidth = '';
      tableElement.style.borderStyle = '';
      tableElement.style.borderColor = '';
  }
}

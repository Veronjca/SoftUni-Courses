function solve() {
  let paragraphElements = Array.from(document.querySelectorAll("p"))
  .forEach((x) => x.addEventListener("click", onClick));
  let resultElement = document.querySelector('.results-inner h1');
  let rightAnswers = 0;

  function onClick(ev){
    let text = ev.currentTarget.textContent;
    if(text == 'onclick'){
      rightAnswers++;
    }else if(text == 'JSON.stringify()'){
      rightAnswers++;
    }else if(text == 'A programming API for HTML and XML documents'){
      rightAnswers++;
    }
    let nextSectionElement = ev.currentTarget.parentNode.parentNode.parentNode.parentNode.nextElementSibling;
    nextSectionElement.previousElementSibling.style.display = 'none';
    if(nextSectionElement.tagName == 'SECTION'){
      nextSectionElement.style.display = 'block';
    }else{
      resultElement.parentNode.parentNode.style.display = 'block';
      if(rightAnswers == 3){
        resultElement.textContent = 'You are recognized as top JavaScript fan!';
       }else{
        resultElement.textContent = `You have ${rightAnswers} right answers`;
       }
    }
  }
}

function create(words) {
   let conteinerElement = document.getElementById('content');
   for (const word of words) {
      let currentDiv = document.createElement('div');
      let currentParagraph = document.createElement('p');
      
      currentParagraph.textContent = word;
      currentParagraph.style.display = 'none';

      currentDiv.addEventListener('click', onClick);
      currentDiv.appendChild(currentParagraph);
      conteinerElement.appendChild(currentDiv);
   }

   function onClick(ev){
      ev.currentTarget.children[0].style.display = 'inline';
   }
}
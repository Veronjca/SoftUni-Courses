window.onload = solution;

async function solution() {
   let baseURL = 'http://localhost:3030/jsonstore/advanced/articles/';

   let responseArticles = await fetch(`${baseURL}list`);
   let titlesArray = await responseArticles.json();

   let mainSection = document.querySelector('#main');

   titlesArray.forEach(x => {
       let mainDiv = document.createElement('div');
       mainDiv.classList.add('accordion');

       let headDiv = document.createElement('div');
       headDiv.classList.add('head');

       let span = document.createElement('span');
       span.textContent = x.title;

       let moreButton = document.createElement('button');
       moreButton.classList.add('button');
       moreButton.setAttribute('id', x._id);
       moreButton.textContent = 'More';

       headDiv.appendChild(span);
       headDiv.appendChild(moreButton);

       let extraDiv = document.createElement('div');
       extraDiv.classList.add('extra');
       extraDiv.style.display = 'none';

       let paragraph = document.createElement('p');
   
       extraDiv.appendChild(paragraph);

       moreButton.addEventListener('click', async () => {
           if(moreButton.textContent === 'More'){
               moreButton.textContent = 'Less';
               extraDiv.style.display = 'block';

               let responseArticle = await fetch(`${baseURL}details/${x._id}`);
               let currentArticle = await responseArticle.json();

               paragraph.textContent = currentArticle.content;
           }else{
            moreButton.textContent = 'More';
            extraDiv.style.display = 'none';
           }
       })

       mainDiv.appendChild(headDiv);
       mainDiv.appendChild(extraDiv);

       mainSection.appendChild(mainDiv);
   });
}
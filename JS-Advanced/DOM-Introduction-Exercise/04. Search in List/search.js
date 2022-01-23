function search() {
   let towns = Array.from(document.getElementById('towns').querySelectorAll('li'));
   let text = document.getElementById('searchText').value;
   let matches = 0;
   towns.forEach(x => {
      x.style.fontWeight = 'normal';
      x.style.textDecoration = 'none';
   })
   towns.forEach(x => {
      if(x.textContent.includes(text)){
         matches++;
         x.style.fontWeight = 'bolder';
         x.style.textDecoration = 'underline';
      }
   })
   document.getElementById('result').textContent = `${matches} matches found`;
}

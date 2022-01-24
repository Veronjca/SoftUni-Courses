function generateReport() {
    let inputFields = document.getElementsByTagName('input');
    let info = document.querySelectorAll('tbody tr');
    let indices = [];
    let result = [];
   for (let i = 0; i < inputFields.length; i++) {
       if(inputFields[i].checked){
           indices.push(i);
       }       
   }

   for (const line of info) {
       let current = {};
       for (let i = 0; i < line.children.length; i++) {
          if(indices.some(x => x == i)){
              current[inputFields[i].name] = line.children[i].textContent;
          }          
       }
       result.push(current);
   }

  document.getElementById('output').value = JSON.stringify(result);   

}
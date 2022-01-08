function sort(array = []){
     array.sort((a,b) => a - b);
     let result = [];
     let length = array.length;
     for (let i = 0; i < length; i++) {
         if(i % 2 == 0){
         result.push(array.shift())
         }else{
             result.push(array.pop());
         }
     }
     return result;
}
console.log(sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
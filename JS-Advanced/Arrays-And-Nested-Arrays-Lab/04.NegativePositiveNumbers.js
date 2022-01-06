function solve(array){
    let result = [];
    array.forEach(element => {
        if(element < 0){
            result.unshift(element);
        }else{
            result.push(element);
        }
    });

   result.forEach(element => {
       console.log(element);
   });   
}
solve([7, -2, 8, 9]);
solve([3, -2, 0, -1]);
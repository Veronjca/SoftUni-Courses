function solve(array){
    let result = [];
    let length;
    array.sort((a,b) => a - b);
    if(array.length % 2 == 0){
        length = array.length / 2;
        result = array.slice(-length);
        return result; 
    }else{
       length = array.length / 2 + 1;
       result = array.slice(-length);
       return result;
    }
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));
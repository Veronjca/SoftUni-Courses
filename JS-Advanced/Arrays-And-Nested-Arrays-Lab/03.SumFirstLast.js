function sum(array){
    array = array.map(Number);
    return array[0] + array[array.length-1];
};

console.log(sum(['5', '10']));
console.log(sum(['20', '30', '40']));

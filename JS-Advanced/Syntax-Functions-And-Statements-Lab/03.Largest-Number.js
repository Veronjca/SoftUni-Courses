function largestNumber(a, b, c){
    let largest = Math.max(a, b, c);
    return `The largest number is ${largest}.`;
};

console.log(largestNumber(5, -3, 16));
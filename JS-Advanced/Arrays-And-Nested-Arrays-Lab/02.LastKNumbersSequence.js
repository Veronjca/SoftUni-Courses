function solve(n, k){
    let array = [1];
    let num = 0;

    for (let i = array.length; i < n; i++) {        
       num = array.slice(-k).reduce((a, v) => a + v, 0);
       array.push(num);
    }
    return array;
};

console.log(solve(6, 3));
console.log(solve(8, 2));
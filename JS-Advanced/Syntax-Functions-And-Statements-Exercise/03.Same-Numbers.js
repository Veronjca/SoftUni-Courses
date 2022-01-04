function sameNumbers(num){
    let number = Number(num.toString()[0]);
    let areSame = num.toString().split('').every(a => a == number);
    let sum = num.toString().split('').map(Number).reduce((a,b) => a + b, 0);

    console.log(areSame);
    console.log(sum);
};

sameNumbers(232);
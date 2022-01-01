function aggreagate(arr){
    let sum = 0;
    let inverseSum = 0;
    let concat = '';
    arr.forEach(element => {
        
        sum += element;
        inverseSum += 1 / element;
        concat += element;
    });

   console.log(sum);
   console.log(inverseSum.toFixed(4));
   console.log(concat);
}

aggreagate([1, 2, 3]);
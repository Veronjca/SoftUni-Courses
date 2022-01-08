function rotate(array, rotations){
    for (let i = 0; i < rotations; i++) {
        array.unshift(array[array.length-1]);
        array.pop();       
    }

    console.log(array.join(' '));
}

rotate(['1', 
'2', 
'3', 
'4'], 
2);
rotate(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
);
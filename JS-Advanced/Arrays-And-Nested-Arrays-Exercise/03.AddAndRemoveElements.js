function solve(input){
    let array = [];
    let counter = 1;
    for (let i = 0; i < input.length; i++) {
        if(input[i] == 'add'){
            array.push(counter);
        }else if(input[i] == 'remove'){           
            array.pop();           
        } 
        counter++;      
    }

    console.log(array.length > 0 ? array.join('\n') : 'Empty');
}

solve(['add', 
'add', 
'add', 
'add']);
solve(['add', 
'add', 
'remove', 
'add', 
'add']);
solve(['remove', 
'remove', 
'remove']
);
function solve(array, delimiter){
    let line = '';
    for (let i = 0; i < array.length; i++) {
        if(i == array.length - 1){
            line += `${array[i]}`; 
        }else{
        line += `${array[i]}${delimiter}`; 
        }      
    }

    console.log(line);
}

solve(['One', 
'Two', 
'Three', 
'Four', 
'Five'], 
'-');
function sort(array){
    array.sort(function(a,b){       
        if(a.length > b.length){return 1}
        if(a.length < b.length){return -1}
        if(a > b){return 1}
        if(a < b){return - 1}       
        return 0;
    });
    console.log(array.join('\n'));
}

sort(['alpha', 
'beta', 
'gamma']);
sort(['Isacc', 
'Theodor', 
'Jack', 
'Harrison', 
'George']);
sort(['test', 
'Deny', 
'omen', 
'Default']);
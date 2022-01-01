function printRectangle(size){
    let line = "* ".repeat(size).trim();
    if(typeof(size) === 'number'){
        for (let i = 0; i < size; i++) {
            
            console.log(line);       
    }
    } else {
        console.log('* * * * *');
        console.log('* * * * *');
    }
};

console.log(printRectangle(1));

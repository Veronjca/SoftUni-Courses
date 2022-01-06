function find(array){
    let line = '';
    for (let i = 0; i < array.length; i+=2) {
       
        line += `${array[i]} `;
    };

    console.log(line);
}

find(['20', '30', '40', '50', '60']);
find(['5', '10']);
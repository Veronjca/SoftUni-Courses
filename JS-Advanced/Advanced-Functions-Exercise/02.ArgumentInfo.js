function solve(...input){
let arguments = input;
let typesCounter = {};

arguments.forEach(element => {
    let type = typeof(element);
    console.log(`${type}: ${element}`);
   if(!typesCounter.hasOwnProperty(type)){
        typesCounter[type] = 0;
   }
   typesCounter[type]++;
});

for (const [prop, value] of Object.entries(typesCounter).sort((a,b) => b[1] - a[1])){
    console.log(`${prop} = ${value}`);
}
}

solve({ name: 'bob'}, 3.333, 9.999);
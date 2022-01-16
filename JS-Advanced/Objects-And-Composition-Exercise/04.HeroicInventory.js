function solve(input){
    let result = [];
    
    for (let i = 0; i < input.length; i++) { 
        let obj = {};       
        let args = input[i].split(' / ');
        let name = args[0];
        let level = Number(args[1]);
        let items = args.length > 2 ? args[2].split(', ') : [];
        Object.assign(obj, {name, level, items});  
        result.push(obj);    
    }

    return JSON.stringify(result);
}
console.log(solve(['Isacc / 25',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']));
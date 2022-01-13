function solve(info){
    let register = {};

    for (let i = 0; i < info.length; i++) {
      let splitted = info[i].split(' <-> ');
      if(!register[splitted[0]]){
        Object.assign(register, {[splitted[0]]: 0})
      }
      register[splitted[0]] += Number(splitted[1]);            
    }

    for (const key in register) {
       console.log(`${key} : ${register[key]}`);
    }
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']);
solve(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']);
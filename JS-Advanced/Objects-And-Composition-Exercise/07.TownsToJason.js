function solve(input) {
  let result = [];
  for (let i = 1; i < input.length; i++) {
    let [Town, Latitude, Longitude] = input[i].split("|").filter((x) => x);
    result.push(
      Object.assign(
        {},
        {
          Town: Town.trim(),
          Latitude: Number(Number(Latitude).toFixed(2)),
          Longitude: Number(Number(Longitude).toFixed(2)),
        }
      )      
    );
  }
  return JSON.stringify(result);
}

console.log(solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']));

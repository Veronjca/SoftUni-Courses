function solve(input) {
  let result = {};
  let smallEngine = { power: 90, volume: 1800 };
  let normalEngine = { power: 120, volume: 2400 };
  let monsterEngine = { power: 200, volume: 3500 };
  let hatchback = { type: "hatchback", color: "" };
  let coupe = { type: "coupe", color: "" };
  result["model"] = input["model"];
  if (input["power"] <= 90) {
    result["engine"] = smallEngine;
  } else if (input["power"] <= 120) {
    result["engine"] = normalEngine;
  } else {
    result["engine"] = monsterEngine;
  }
  hatchback["color"] = input["color"];
  coupe["color"] = input["color"];

  if (input["carriage"] == "hatchback") {
    result["carriage"] = hatchback;
  } else {
    result["carriage"] = coupe;
  }

  if(input['wheelsize'] % 2 === 0){
      input['wheelsize']--;
  }

  let wheels = [];
  for (let i = 0; i < 4; i++) {
      wheels.push(input['wheelsize']);      
  }
  result['wheels'] = wheels;
return result;
}
console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }));

function solve(commands) {
  let objects = {};

  let modifier = {
    create(name) {
      objects[name] = {};
    },
    createAndInherit(name, parentName) {
    modifier.create(name);
      objects[name] = Object.setPrototypeOf(objects[name], objects[parentName]);
    },
    set(objName, propName, propValue) {
      objects[objName][propName] = propValue;
    },
    print(objName) {
      let result = [];
      for (const key in objects[objName]) {
        result.push(`${key}:${objects[objName][key]}`);
      }
      console.log(result.join(","));
    },
  };

  for (const command of commands) {
    let currentCommands = command.split(" ");
    if (currentCommands[0] === "create" && currentCommands.length === 2) {
      let name = currentCommands[1];
      modifier.create(name);
    } else if (
      currentCommands[0] === "create" &&
      currentCommands.length === 4
    ) {
      let name = currentCommands[1];
      let parentName = currentCommands[3];
      modifier.createAndInherit(name, parentName);
    } else if (currentCommands[0] === "set") {
      let name = currentCommands[1];
      let propName = currentCommands[2];
      let propValue = currentCommands[3];
      modifier.set(name, propName, propValue);
    } else if (currentCommands[0] === "print") {
      let name = currentCommands[1];
      modifier.print(name);
    }
  }
}

solve([
  "create c1",
  "create c2 inherit c1",
  "set c1 color red",
  "set c2 model new",
  "print c1",
  "print c2",
]);


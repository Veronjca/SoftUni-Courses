function solve(input) {
  let obj = {};
  for (let i = 0; i < input.length; i++) {
    if (i % 2 == 0) {
      Object.assign(obj, { [input[i]]: Number(0)});
    } else {
        obj[input[i-1]] += Number(input[i]);
    }
  }
  console.log(obj);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);

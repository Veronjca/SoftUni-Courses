function vol() {
  return Math.abs(this.x * this.y * this.z);
}

function area() {
  return Math.abs(this.x * this.y);
}

function solve(area, vol, input) {
  let figures = JSON.parse(input);
  let result = [];

  figures.forEach(element => {
      let current = {};
      current['area'] = area.call(element);
      current['volume'] = vol.call(element);
      result.push(current);
  });

  return result;
}
console.log(solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`));

(function solve() {
  Array.prototype.last = function() {
    return this[this.length - 1];
  };
  Array.prototype.skip = function(value) {
    let n = Number(value);
    return this.slice(n);
  };
  Array.prototype.take = function(value) {
    let n = Number(value);
    return this.slice(0, n);
  };
  Array.prototype.sum = function() {
    return this.reduce((a, b) => a + b);
  };
  Array.prototype.average = function() {
    return this.reduce((a, b) => a + b) / this.length;
  };

//   let arr = [1,2,4];
//   console.log(arr.sum());
//   console.log(arr.skip(2));
//   console.log(arr.take(2));
//   console.log(arr.last());
//   console.log(arr.average());
})()
solve();

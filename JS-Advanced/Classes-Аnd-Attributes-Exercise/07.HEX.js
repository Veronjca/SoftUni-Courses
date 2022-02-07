class Hex {
  constructor(value) {
    this.number = Number(value);
  }

  valueOf() {
    return this.number;
  }

  toString() {
    return "0x" + this.number.toString(16).toUpperCase();
  }

  plus(obj) {
    if (typeof(obj) === "object") {
      return new Hex(obj.valueOf() + this.valueOf());
    }
    return new Hex(obj);
  }

  minus(obj) {
    if (typeof(obj) === "object") {
        return new Hex(Math.abs(obj.valueOf() - this.valueOf()));
      }
      return new Hex(obj);
  }

  parse(string) {
    return parseInt(string, 16);
  }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse("AAA"));

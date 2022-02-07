class Stringer {
  constructor(innerString, innerLength) {
    this.innerString = innerString;
    this.innerLength = innerLength;
    this.string = innerString;
  }

  increase(value) {
    this.innerLength += value;
  }

  decrease(value) {
    this.innerLength -= value;
    if (this.innerLength < 0) {
      this.innerLength = 0;
    }
  }

  toString() {
    if (this.innerLength === 0) {
      return "...";
    } else if (this.innerString.length > this.innerLength) {
      let difference =this.innerString.length -this.innerLength;
      let result = this.innerString.slice(0, difference) + '...';
      return result;
    }
    return this.innerString;
  }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test

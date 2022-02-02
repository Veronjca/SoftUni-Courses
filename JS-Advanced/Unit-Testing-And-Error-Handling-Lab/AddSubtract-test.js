let createCalculator = require("./07.AddSubtract");
let expect = require("chai").expect;

describe("Add abstract tests", () => {
  it("Function should return object with add, subtract and get methods", () => {
    let obj = createCalculator();

    expect(obj).to.haveOwnProperty("add");
    expect(obj).to.haveOwnProperty("subtract");
    expect(obj).to.haveOwnProperty("get");
  });

  it("Function should return NaN when trying to add string or object", () => {
    let obj = createCalculator();
    obj.add("bbb");
    let result = obj.get();
    expect(result).to.be.NaN;
    obj.add({});
    let secondResult = obj.get();
    expect(secondResult).to.be.NaN;
  });

  it("Function should return NaN when trying to subtract string", () => {
    let obj = createCalculator();
    obj.subtract("bbb");
    let result = obj.get();
    expect(result).to.be.NaN;
  });
  it("Function should return zero when adding empty array", () => {
    let obj = createCalculator();
    obj.add([]);
    let result = obj.get();
    expect(result).to.equal(0);
  });
  it("Function should return object", () => {
    let obj = createCalculator();
    let type = typeof obj;
    expect("object").to.equal(type);
  });
  it("Function should add and subtract when everything is fine", () => {
    let obj = createCalculator();
    obj.add(5);
    obj.subtract(2);
    let result = obj.get();
    expect(result).to.equal(3);
  });
  it('Function should parse successfully string representation of numbers', () => {
      let obj = createCalculator();
      obj.add('6');
      obj.subtract('3');
      let result = obj.get();
      expect(3).to.equal(result);
  })
});

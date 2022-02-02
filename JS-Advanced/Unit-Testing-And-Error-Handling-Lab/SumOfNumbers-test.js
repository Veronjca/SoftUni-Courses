const sum = require("./04.SumOfNumbers");
const expect = require("chai").expect;

describe("Sum of numbers tests", () => {
  it("Function should sum numbers", () => {
    let arr = [1, 2, 3];
    let expected = 6;
    expect(expected).to.equal(sum(arr));
  });

  it("Function should return NaN when one of array parameters is not number", () => {
    let arr = [1, "two", 3];
    expect(sum(arr)).to.be.NaN;
  });

  it("Function should return zero when empty array is passed", () => {
    let arr = [];
    expect(sum(arr)).to.equal(0);
  });

  it("Function should work properly when one of the arguments in the array is negative number", () => {
    let arr = [1, 2, 3, -3];
    let expected = 3;
    expect(sum(arr)).to.equal(expected);
  });
});

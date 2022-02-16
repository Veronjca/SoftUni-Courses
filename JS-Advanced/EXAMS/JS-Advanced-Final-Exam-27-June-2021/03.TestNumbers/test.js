const testNumbers = require("./testNumbers");
const expect = require("chai").expect;

describe("Test Numbers tests", () => {
  it("sumNumbers method should return undefined when first parameter is not numbers", () => {
    expect(testNumbers.sumNumbers("bb", 5)).to.be.undefined;
    expect(testNumbers.sumNumbers("5", 5)).to.be.undefined;
    expect(testNumbers.sumNumbers({}, 5)).to.be.undefined;
    expect(testNumbers.sumNumbers([], 5)).to.be.undefined;
    expect(testNumbers.sumNumbers(false, 5)).to.be.undefined;
    expect(testNumbers.sumNumbers(true, 5)).to.be.undefined;
  });

  it("sumNumbers method should return undefined when second parameter is not numbers", () => {
    expect(testNumbers.sumNumbers(5, "bb")).to.be.undefined;
    expect(testNumbers.sumNumbers(5, "5")).to.be.undefined;
    expect(testNumbers.sumNumbers(5, {})).to.be.undefined;
    expect(testNumbers.sumNumbers(5, [])).to.be.undefined;
    expect(testNumbers.sumNumbers(5, false)).to.be.undefined;
    expect(testNumbers.sumNumbers(5, true)).to.be.undefined;
  });

  it("sumNumbers method should return undefined when both parameters are not numbers", () => {
    expect(testNumbers.sumNumbers("bb", "bb")).to.be.undefined;
    expect(testNumbers.sumNumbers("5", "5")).to.be.undefined;
    expect(testNumbers.sumNumbers({}, {})).to.be.undefined;
    expect(testNumbers.sumNumbers([], [])).to.be.undefined;
    expect(testNumbers.sumNumbers(false, false)).to.be.undefined;
    expect(testNumbers.sumNumbers(true, true)).to.be.undefined;
  });

  it("sumNumbers method should return the sum of the params when params are correct", () => {
    let result = testNumbers.sumNumbers(5, 5);
    let expected = "10.00";
    expect(result).to.equal(expected);

    result = testNumbers.sumNumbers(-1, -1);
    expected = "-2.00";
    expect(result).to.equal(expected);

    result = testNumbers.sumNumbers(0, 0);
    expected = "0.00";
    expect(result).to.equal(expected);

    result = testNumbers.sumNumbers(5.5, 5.5);
    expected = "11.00";
    expect(result).to.equal(expected);
  });

  it("numberChecker method should throw Error when input param is not convertable to number", () => {
    expect(() => testNumbers.numberChecker({})).to.throw(Error, "The input is not a number!");
    expect(() => testNumbers.numberChecker("bbbb")).to.throw(Error, "The input is not a number!");
    expect(() => testNumbers.numberChecker("123bbbb")).to.throw(Error, "The input is not a number!");
    expect(() => testNumbers.numberChecker("123.45bbbb")).to.throw(Error, "The input is not a number!");
    expect(() => testNumbers.numberChecker(NaN)).to.throw(Error, "The input is not a number!");
  });

  it("numberChecker method should return message when input number is even", () => {
    let result = testNumbers.numberChecker(2);
    let expected = "The number is even!";
    expect(result).to.equal(expected);

    result = testNumbers.numberChecker(0);
    expect(result).to.equal(expected);

    result = testNumbers.numberChecker(-2);
    expect(result).to.equal(expected);
  });

  it("numberChecker method should return message when input number is odd", () => {
    let result = testNumbers.numberChecker(1);
    let expected = "The number is odd!";
    expect(result).to.equal(expected);

    result = testNumbers.numberChecker(-1);
    expect(result).to.equal(expected);

    result = testNumbers.numberChecker(7);
    expect(result).to.equal(expected);
  });

  it("averageSumArray method should return average sum of array of numbers", () => {
    let result = testNumbers.averageSumArray([5]);
    let expected = 5;
    expect(result).to.equal(expected);

    result = testNumbers.averageSumArray([5, 5, 5]);
    expected = 5;
    expect(result).to.equal(expected);
  });
});

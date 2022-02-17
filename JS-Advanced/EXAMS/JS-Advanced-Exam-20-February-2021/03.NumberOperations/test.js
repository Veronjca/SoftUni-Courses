const numberOperations = require("./NumberOperations");
const expect = require("chai").expect;

describe("Number Operations tests", () => {
  it("powNumber method should return the power of the given number", () => {
    let result = numberOperations.powNumber(2);
    let expected = 4;
    expect(result).to.equal(expected);

    result = numberOperations.powNumber(0);
    expected = 0;
    expect(result).to.equal(expected);

    result = numberOperations.powNumber(-1);
    expected = 1;
    expect(result).to.equal(expected);
  });

  it("numberChecker method should throw error when input is not a number", () => {
    expect(() => numberOperations.numberChecker({})).to.throw(Error, "The input is not a number!");
    expect(() => numberOperations.numberChecker("bbbb")).to.throw(Error, "The input is not a number!");
    expect(() => numberOperations.numberChecker("123bbbb")).to.throw(Error, "The input is not a number!");
    expect(() => numberOperations.numberChecker("123.45bbbb")).to.throw(Error, "The input is not a number!");
    expect(() => numberOperations.numberChecker(NaN)).to.throw(Error, "The input is not a number!");
  });

  it("numberChecker method should return messafe when input number is less than 100", () => {
    let result = numberOperations.numberChecker(99);
    let expected = "The number is lower than 100!";
    expect(result).to.equal(expected);

    result = numberOperations.numberChecker(50);
    expect(result).to.equal(expected);

    result = numberOperations.numberChecker(0);
    expect(result).to.equal(expected);

    result = numberOperations.numberChecker(99.99);
    expect(result).to.equal(expected);

    result = numberOperations.numberChecker(-1);
    expect(result).to.equal(expected);
  });

  it("numberChecker method should return messafe when input number is bigger than or equal to 100", () => {
    let result = numberOperations.numberChecker(100);
    let expected = "The number is greater or equal to 100!";
    expect(result).to.equal(expected);

    result = numberOperations.numberChecker(101);
    expect(result).to.equal(expected);

    result = numberOperations.numberChecker(100.01);
    expect(result).to.equal(expected);

    result = numberOperations.numberChecker(2000);
    expect(result).to.equal(expected);
  });

  it('sumArrays method should be summing input arrays correctly', () => {
      let result = numberOperations.sumArrays([1, 2, 3], [1, 2, 3]);
      let expected = [2, 4, 6];
      expect(result).to.deep.equal(expected);

      result = numberOperations.sumArrays([1, 2, 3, 4], [1, 2]);
      expected = [2, 4, 3, 4];
      expect(result).to.deep.equal(expected);

      result = numberOperations.sumArrays([1, 2], [1, 2, 5, 6]);
      expected = [2, 4, 5, 6];
      expect(result).to.deep.equal(expected);

      result = numberOperations.sumArrays([1], [1]);
      expected = [2];
      expect(result).to.deep.equal(expected);
  })
});

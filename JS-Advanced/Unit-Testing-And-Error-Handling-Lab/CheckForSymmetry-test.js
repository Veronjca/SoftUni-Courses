const isSymmetric = require("./05.CheckForSymmetry");
const expect = require("chai").expect;

describe("Check for symmetry tests", () => {
  it("Function should return false when non-array is passed", () => {
    expect(false).to.equal(isSymmetric("non-array"));
    expect(false).to.equal(isSymmetric(undefined));
    expect(false).to.equal(isSymmetric(2));
    expect(false).to.equal(isSymmetric(null));
  });
  it("Function should return true when passed array is symmetric", () => {
    let arr = [1, 2, 1];
    expect(true).to.equal(isSymmetric(arr));
  });
  it("Function should return false when passed array is not symmetric", () => {
    let arr = [1, 2, 3, 4];
    expect(false).to.equal(isSymmetric(arr));
  });
  it("Function should return true when arrays is symmetric but with mixed data", () => {
    let arr = [0, true, 0];
    expect(true).to.equal(isSymmetric(arr));
  });
  it("Function should return false when symetric array with mixed data is passed", () => {
    let arr = [1, 2, '1'];
    expect(false).to.equal(isSymmetric(arr));
  });
});

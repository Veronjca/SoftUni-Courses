let isOddOrEven = require("./02.evenOrOdd");
let expect = require("chai").expect;

  it("Should return undefined when non string is passed", () => {
    expect(isOddOrEven(2)).to.be.undefined;
    expect(isOddOrEven([])).to.be.undefined;
    expect(isOddOrEven({})).to.be.undefined;
    expect(isOddOrEven(true)).to.be.undefined;
    expect(isOddOrEven(23.5)).to.be.undefined;
  });

  it("Should return even when the length of the passed string is even number", () => {
    expect(isOddOrEven('bbbb')).to.equal('even');
  });

  it("Should return odd when the length of the passed string is odd number", () => {
    expect(isOddOrEven('bbb')).to.equal('odd');
  });



const rgbToHexColor = require("./06.RGBToHex");
const expect = require("chai").expect;

describe("RGB to Hex tests", () => {
  it("Function should return undefined when red value is invalid", () => {
    expect(undefined).to.equal(rgbToHexColor(23.4, 2, 3));
    expect(undefined).to.equal(rgbToHexColor("a", 2, 3));
    expect(undefined).to.equal(rgbToHexColor(null, 2, 3));
    expect(undefined).to.equal(rgbToHexColor(undefined, 2, 3));
    expect(undefined).to.equal(rgbToHexColor("23", 2, 3));
    expect(undefined).to.equal(rgbToHexColor(300, 2, 3));
    expect(undefined).to.equal(rgbToHexColor(-1, 2, 3));
  });
  it("Function should return undefined when green value is invalid", () => {
    expect(undefined).to.equal(rgbToHexColor(2, "2", 3));
    expect(undefined).to.equal(rgbToHexColor(2, "abc", 3));
    expect(undefined).to.equal(rgbToHexColor(2, null, 3));
    expect(undefined).to.equal(rgbToHexColor(2, undefined, 3));
    expect(undefined).to.equal(rgbToHexColor(2, 23.5, 3));
    expect(undefined).to.equal(rgbToHexColor(2, 300, 3));
    expect(undefined).to.equal(rgbToHexColor(2, -1, 3));
  });
  it("Function should return undefined when blue value is invalid", () => {
    expect(undefined).to.equal(rgbToHexColor(2, 3, 23.5));
    expect(undefined).to.equal(rgbToHexColor(2, 3, "abc"));
    expect(undefined).to.equal(rgbToHexColor(2, 3, null));
    expect(undefined).to.equal(rgbToHexColor(2, 3, undefined));
    expect(undefined).to.equal(rgbToHexColor(2, 3, "23"));
    expect(undefined).to.equal(rgbToHexColor(2, 3, 300));
    expect(undefined).to.equal(rgbToHexColor(2, 3, -1));
  });
  it('Function should work properly when input data is correct', () =>{
    let expected =  '#FF9EAA';
    expect(expected).to.equal(rgbToHexColor(255,158,170));
  })
  it('Function should work properly when only zeros are passed', () => {
    let expected = '#000000';
    expect(expected).to.equal(rgbToHexColor(0,0,0));
  })
  it('Function should work properly when all input values are at upper limit', () => {
    let expected = '#FFFFFF';
    expect(expected).to.equal(rgbToHexColor(255,255,255));
  })
});

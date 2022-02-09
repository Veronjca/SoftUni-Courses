const StringBuilder = require("./stringBuilder");
const expect = require("chai").expect;

describe("String Builder tests", () => {
  let builder = new StringBuilder();
  it("Should be able to be instantinated without param", () => {
    expect(builder._stringArray).to.be.an("array");
    builder = new StringBuilder(undefined);
    expect(builder._stringArray).to.be.an("array");
  });
  it("Should be able to be instantinated with param", () => {
    builder = new StringBuilder("hello");
    expect(builder._stringArray).to.be.an("array");
    builder = new StringBuilder("");
    expect(builder._stringArray).to.be.an("array");
  });
  it("Constructor should throw error when passed parameter is not a string", () => {
    expect(() => (builder = new StringBuilder(2))).to.throw(TypeError, "Argument must be a string");
    expect(() => (builder = new StringBuilder(true))).to.throw(TypeError, "Argument must be a string");
    expect(() => (builder = new StringBuilder([]))).to.throw(TypeError, "Argument must be a string");
    expect(() => (builder = new StringBuilder({}))).to.throw(TypeError, "Argument must be a string");
    expect(() => (builder = new StringBuilder(-1))).to.throw(TypeError, "Argument must be a string");
    expect(() => (builder = new StringBuilder(25.6))).to.throw(TypeError, "Argument must be a string");
  });
  it("Append method should throw error when passed parameter is not a string", () => {
    expect(() => builder.append(2)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.append(-1)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.append(2.5)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.append([])).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.append({})).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.append(false)).to.throw(TypeError, "Argument must be a string");
  });
  it("Append method should work properly", () => {
    builder = new StringBuilder("hello");
    builder.append(" there");
    let expected = "hello there";
    expect(expected).to.equal(builder.toString());
  });
  it("Prepend method should throw error when passed parameter is not a string", () => {
    expect(() => builder.prepend(2)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.prepend(-1)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.prepend(2.5)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.prepend([])).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.prepend({})).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.prepend(true)).to.throw(TypeError, "Argument must be a string");
  });
  it("Prepend method should work properly", () => {
    builder = new StringBuilder("hello");
    builder.prepend("hello ");
    let expected = "hello hello";
    expect(expected).to.equal(builder.toString());
  });
  it("insertAt method should throw error when passed parameter is not a string", () => {
    expect(() => builder.insertAt(2, 1)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.insertAt(-1, 1)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.insertAt(2.5, 1)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.insertAt([], 1)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.insertAt({}, 1)).to.throw(TypeError, "Argument must be a string");
    expect(() => builder.insertAt(true, 1)).to.throw(TypeError, "Argument must be a string");
  });
  it("insertAt method should work properly", () => {
    builder = new StringBuilder("he ");
    builder.insertAt("llo", 2);
    let expected = "hello ";
    expect(expected).to.equal(builder.toString());

    builder = new StringBuilder("hello");
    builder.insertAt('hi ', 0);
    expected = 'hi hello';
    expect(expected).to.equal(builder.toString());

    builder = new StringBuilder("hello");
    builder.insertAt(' there', 5);
    expected = 'hello there';
    expect(expected).to.equal(builder.toString()); 
    
    builder = new StringBuilder();
    builder.insertAt('hello', 0);
    expected = 'hello';
    expect(expected).to.equal(builder.toString());  
  });
  it('Remove method should work properly', () => {
      builder = new StringBuilder('hello');
      builder.remove(2,2);
      let expected = 'heo';
      expect(builder.toString()).to.equal(expected);

      builder = new StringBuilder('hello');
      builder.remove(0, 1);
      expected = 'ello';
      expect(builder.toString()).to.equal(expected);

      builder = new StringBuilder('hello');
      builder.remove(4, 1);
      expected = 'hell';
      expect(builder.toString()).to.equal(expected);

      builder = new StringBuilder('hello');
      builder.remove(4, 0);
      expected = 'hello';
      expect(builder.toString()).to.equal(expected);
  })
  it('toString method should work properly', () => {
    builder = new StringBuilder('hello');
    expect(builder.toString()).to.equal('hello');

    builder = new StringBuilder();
    expect(builder.toString()).to.be.empty;

    builder = new StringBuilder('');
    expect(builder.toString()).to.be.empty;

    builder = new StringBuilder(undefined);
    expect(builder.toString()).to.be.empty;
  })
  it('All methods should work correctly together', () => {
    let str = new StringBuilder('hello');
    str.append(', there');
    str.prepend('User, ');
    str.insertAt('woop',5 );
    str.remove(6, 3);
    expect(str.toString()).to.equal('User,w hello, there');
  })
});

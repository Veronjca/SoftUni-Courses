const PaymentPackage = require("./12.paymentPackage");
let expect = require("chai").expect;

describe("Payment Package class tests", () => {
  it("Constructor should work properly", () => {
    let package = new PaymentPackage("blah", 50);
    expect("blah").to.equal(package.name);
    expect(50).to.equal(package.value);
    expect(20).to.equal(package.VAT);
    expect(package.active).to.be.true;
  });
  it('Name should change via setter', () => {
    let package = new PaymentPackage("blah", 50);
    package.name = 'ugh';
    expect('ugh').to.equal(package.name);

  })
  it('Value should change via setter', () => {
    let package = new PaymentPackage("blah", 50);
    package.value = 100;
    expect(package.value).to.equal(100);
    package.value = 0.5;
    expect(package.value).to.equal(0.5);
  })
  it('VAT should change via setter', () => {
    let package = new PaymentPackage("blah", 50);
    package.VAT =  30;
    expect(30).to.equal(package.VAT);
    package.VAT =  0.5;
    expect(0.5).to.equal(package.VAT);
  })
  it('Active should change via setter', () => {
    let package = new PaymentPackage("blah", 50);
    package.active =  false;
    expect(package.active).to.be.false;
    package.active =  true;
    expect(package.active).to.be.true;
  })
  it('Constructor should throw error when trying to set non-string to name property, or value length equals zero',() => {
    expect(() => {new PaymentPackage(50, 50)}).to.throw(Error, 'Name must be a non-empty string');
    expect(() => {new PaymentPackage('', 50)}).to.throw(Error, 'Name must be a non-empty string');
    expect(() => {new PaymentPackage([], 50)}).to.throw(Error, 'Name must be a non-empty string');
    expect(() => {new PaymentPackage({}, 50)}).to.throw(Error, 'Name must be a non-empty string');
    expect(() => {new PaymentPackage(true, 50)}).to.throw(Error, 'Name must be a non-empty string');
  })
  it('Constructor should throw error when trying to set non-number to value property, or passed value is less than zero',() => {
    expect(() => {new PaymentPackage('blah', 'ugh')}).to.throw(Error, 'Value must be a non-negative number');
    expect(() => {new PaymentPackage('blah', -1)}).to.throw(Error, 'Value must be a non-negative number');
    expect(() => {new PaymentPackage('blah', '1')}).to.throw(Error, 'Value must be a non-negative number');
    expect(() => {new PaymentPackage('blah', true)}).to.throw(Error, 'Value must be a non-negative number');
    expect(() => {new PaymentPackage('blah', [])}).to.throw(Error, 'Value must be a non-negative number');
    expect(() => {new PaymentPackage('blah', {})}).to.throw(Error, 'Value must be a non-negative number');
  })
  it('VAT setter should throw error when passed value is not a number or less than zero', () => {
    let package = new PaymentPackage("blah", 50);
    expect(() => {package.VAT = 'blah'}).to.throw(Error, 'VAT must be a non-negative number');
    expect(() => {package.VAT = -1}).to.throw(Error, 'VAT must be a non-negative number');
    expect(() => {package.VAT = '1'}).to.throw(Error, 'VAT must be a non-negative number');
    expect(() => {package.VAT = true}).to.throw(Error, 'VAT must be a non-negative number');
    expect(() => {package.VAT = []}).to.throw(Error, 'VAT must be a non-negative number');
    expect(() => {package.VAT = {}}).to.throw(Error, 'VAT must be a non-negative number');
  })
  it('Active setter should throw error when passed value is not a boolean', () => {
    let package = new PaymentPackage("blah", 50);
    expect(() => {package.active = 'blah'}).to.throw(Error, 'Active status must be a boolean');
    expect(() => {package.active = -1}).to.throw(Error, 'Active status must be a boolean');
    expect(() => {package.active = 10}).to.throw(Error, 'Active status must be a boolean');
  })
  it('to String method should work properly', () => {
    let package = new PaymentPackage("blah", 50);
    let expected =`Package: ${package.name}` + '' + '\n';
    expected += `- Value (excl. VAT): ${package.value}\n`;
    expected += `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`;
    expect(expected).to.equal(package.toString());

    package.active = false;
    expected =`Package: ${package.name}` + ' (inactive)' + '\n';
    expected += `- Value (excl. VAT): ${package.value}\n`;
    expected += `- Value (VAT ${package.VAT}%): ${package.value * (1 + package.VAT / 100)}`;
    expect(expected).to.equal(package.toString());

    package = new PaymentPackage("blah", 0);
    package.VAT = 0;
    expected =`Package: ${package.name}` + '' + '\n';
    expected += `- Value (excl. VAT): 0\n`;
    expected += `- Value (VAT 0%): 0`;
    expect(expected).to.equal(package.toString());
  })
});

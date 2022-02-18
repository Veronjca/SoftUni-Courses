const dealership = require("./dealership");
const expect = require("chai").expect;

describe("Dealership tests", () => {
  it("newCarCost method should return different price when paased car model have discount", () => {
    expect(dealership.newCarCost("Audi A4 B8", 50000)).to.equal(35000);
    expect(dealership.newCarCost("Audi A6 4K", 50000)).to.equal(30000);
    expect(dealership.newCarCost("Audi A8 D5", 50000)).to.equal(25000);
    expect(dealership.newCarCost("Audi TT 8J", 50000)).to.equal(36000);
  });

  it("newCarCost method should return new car price when paased car model dont have discount", () => {
    expect(dealership.newCarCost("Audi", 50000)).to.equal(50000);
    expect(dealership.newCarCost("BMW", 30000)).to.equal(30000);
  });

  it('carEquipment method should return selected extras', () => {
    let actual = dealership.carEquipment(['climatronic', 'heated seats', 'navigation system'], [0,1]);
    let expected = ['climatronic', 'heated seats'];
    expect(actual).to.deep.equal(expected);

    actual = dealership.carEquipment(['climatronic', 'heated seats', 'navigation system'], [0]);
    expected = ['climatronic'];
    expect(actual).to.deep.equal(expected);

    actual = dealership.carEquipment(['climatronic', 'heated seats', 'navigation system'], []);
    expected = [];
    expect(actual).to.deep.equal(expected);
  })

  it('euroCategory method should return message when category is less than 4', () => {
    let actual = dealership.euroCategory(3);
    let expected = 'Your euro category is low, so there is no discount from the final price!';
    expect(actual).to.equal(expected);

    actual = dealership.euroCategory(0);
    expect(actual).to.equal(expected);
  })

  
  it('euroCategory method should return message when category is bigger than or equal to 4', () => {
    let actual = dealership.euroCategory(4);
    let expected = `We have added 5% discount to the final price: 14250.`;
    expect(actual).to.equal(expected);

    actual = dealership.euroCategory(5);
    expect(actual).to.equal(expected);

    actual = dealership.euroCategory(6);
    expect(actual).to.equal(expected);
  })
});

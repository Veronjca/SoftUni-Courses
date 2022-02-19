const flowerShop = require("./flowerShop");
const expect = require("chai").expect;

describe("Flowers Shop tests", () => {
  it("calcPriceOfFlowers method should throw error when flower is not of type string", () => {
    expect(() => flowerShop.calcPriceOfFlowers([], 5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers({}, 5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers(5, 5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers(5.5, 5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers(false, 5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers(true, 5, 5)).to.throw(Error, "Invalid input!");
  });

  it("calcPriceOfFlowers method should throw error when price is not of type integer", () => {
    expect(() => flowerShop.calcPriceOfFlowers("tulip", "5", 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5.5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", true, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", false, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", [], 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", {}, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", "vvv", 5)).to.throw(Error, "Invalid input!");
  });

  it("calcPriceOfFlowers method should throw error when quantity is not of type integer", () => {
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5, "5")).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5, 5.5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5, true)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5, false)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5, [])).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5, {})).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.calcPriceOfFlowers("tulip", 5, "vvvv")).to.throw(Error, "Invalid input!");
  });

  it("calcPriceOfFlowers method should throw error when all params are not valid", () => {
    expect(() => flowerShop.calcPriceOfFlowers(5, 5.5, "5")).to.throw(Error, "Invalid input!");
  });

  it("calcPriceOfFlowers method should return message when inputs are valid", () => {
    let actual = flowerShop.calcPriceOfFlowers("tulip", 5, 5);
    let expected = `You need $25.00 to buy tulip!`;
    expect(actual).to.equal(expected);

    actual = flowerShop.calcPriceOfFlowers("tulip", 0, 5);
    expected = `You need $0.00 to buy tulip!`;
    expect(actual).to.equal(expected);

    actual = flowerShop.calcPriceOfFlowers("tulip", 5, 0);
    expected = `You need $0.00 to buy tulip!`;
    expect(actual).to.equal(expected);

    actual = flowerShop.calcPriceOfFlowers("tulip", 0, 0);
    expected = `You need $0.00 to buy tulip!`;
    expect(actual).to.equal(expected);
  });

  it("checkFlowersAvailable method should return message when flower is available", () => {
    let actual = flowerShop.checkFlowersAvailable("tulip", ["tulip", "rose", "daisy"]);
    let expected = `The tulip are available!`;
    expect(actual).to.equal(expected);

    actual = flowerShop.checkFlowersAvailable("daisy", ["tulip", "rose", "daisy"]);
    expected = `The daisy are available!`;
    expect(actual).to.equal(expected);

    actual = flowerShop.checkFlowersAvailable("daisy", ["daisy"]);
    expected = `The daisy are available!`;
    expect(actual).to.equal(expected);
  });

  it("checkFlowersAvailable method should return message when flower is not available", () => {
    let actual = flowerShop.checkFlowersAvailable("sunflower", ["tulip", "rose", "daisy"]);
    let expected = `The sunflower are sold! You need to purchase more!`;
    expect(actual).to.equal(expected);

    actual = flowerShop.checkFlowersAvailable("daisy", []);
    expected = `The daisy are sold! You need to purchase more!`;
    expect(actual).to.equal(expected);

    actual = flowerShop.checkFlowersAvailable("rose", ["daisy"]);
    expected = `The rose are sold! You need to purchase more!`;
    expect(actual).to.equal(expected);
  });

  it("sellFlowers method should throw error when garden is not of type array", () => {
    expect(() => flowerShop.sellFlowers({}, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers(true, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers(false, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers(5.5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers(5, 5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers('bb', 5)).to.throw(Error, "Invalid input!");
  });

  it("sellFlowers method should throw error when space is not of type integer", () => {
    expect(() => flowerShop.sellFlowers([], 5.5)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers([], 'vvv')).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers([], false)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers([], true)).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers([], [])).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers([], {})).to.throw(Error, "Invalid input!");
  });

  
  it("sellFlowers method should throw error when space is less than zero", () => {
    expect(() => flowerShop.sellFlowers([], -1 )).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers([], -5)).to.throw(Error, "Invalid input!");
  });

  it("sellFlowers method should throw error when space is bigger than or equal to garden length", () => {
    expect(() => flowerShop.sellFlowers()).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers(['tulip', 'sunflower', 'daisy'], 4 )).to.throw(Error, "Invalid input!");
    expect(() => flowerShop.sellFlowers(['tulip', 'sunflower', 'daisy'], 10 )).to.throw(Error, "Invalid input!");

  });

  it("sellFlowers method should work properly when input is valid", () => {
    let actual = flowerShop.sellFlowers(['tulip', 'sunflower', 'daisy'], 2);
    let expected = 'tulip / sunflower';
    expect(actual).to.equal(expected);

    actual = flowerShop.sellFlowers(['tulip', 'sunflower', 'daisy'], 0);
    expected = 'sunflower / daisy';
    expect(actual).to.equal(expected);

    actual = flowerShop.sellFlowers(['tulip', 'sunflower', 'daisy'], 1);
    expected = 'tulip / daisy';
    expect(actual).to.equal(expected);

    actual = flowerShop.sellFlowers(['tulip', 'sunflower'], 0);
    expected = 'sunflower';
    expect(actual).to.equal(expected);

  });
});

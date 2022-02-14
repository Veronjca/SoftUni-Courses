const cinema = require("./cinema");
const expect = require("chai").expect;

describe("Cinema tests", () => {
  it("showMovies method should return message when passed param length is zero", () => {
    let expected = "There are currently no movies to show.";
    let result = cinema.showMovies([]);
    expect(result).to.equal(expected);
  });

  it("showMovies method should work properly with valid param", () => {
    let expected = "Paf, Viki, Emre";
    let result = cinema.showMovies(["Paf", "Viki", "Emre"]);
    expect(result).to.equal(expected);

    expected = "Paf";
    result = cinema.showMovies(["Paf"]);
    expect(result).to.equal(expected);
  });

  it("ticketPrice method should throw Error when invalid projection type is passed", () => {
    expect(() => cinema.ticketPrice("blah")).to.throw(Error, "Invalid projection type.");
    expect(() => cinema.ticketPrice("")).to.throw(Error, "Invalid projection type.");
    expect(() => cinema.ticketPrice([])).to.throw(Error, "Invalid projection type.");
    expect(() => cinema.ticketPrice({})).to.throw(Error, "Invalid projection type.");
    expect(() => cinema.ticketPrice(true)).to.throw(Error, "Invalid projection type.");
    expect(() => cinema.ticketPrice(false)).to.throw(Error, "Invalid projection type.");
    expect(() => cinema.ticketPrice(5)).to.throw(Error, "Invalid projection type.");
    expect(() => cinema.ticketPrice(5.5)).to.throw(Error, "Invalid projection type.");
  });

  it("ticketPrice method should return valid ticket price when projection type is valid", () => {
    let result = cinema.ticketPrice("Premiere");
    let expected = 12.00;
    expect(result).to.equal(expected);

    result = cinema.ticketPrice("Normal");
    expected = 7.50;
    expect(result).to.equal(expected);

    result = cinema.ticketPrice("Discount");
    expected = 5.50;
    expect(result).to.equal(expected);
  });

  it("swapSeatsInHall method should return message when first place value is not an integer, is negatuve number or bigger than 20", () => {
    let expected = "Unsuccessful change of seats in the hall.";
    let result = cinema.swapSeatsInHall("bbb", 5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(23.5, 5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(0, 5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(-1, 5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(21, 5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(50, 5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall('5', 5);
    expect(result).to.equal(expected);
  });

  it("swapSeatsInHall method should return message when second place value is not an integer, is negatuve number or bigger than 20", () => {
    let expected = "Unsuccessful change of seats in the hall.";
    let result = cinema.swapSeatsInHall(5, "bbb");
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(5, 5.5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(5, 0);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(5, -1);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(5, 21);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(5, 50);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(5, '5');
    expect(result).to.equal(expected);
  });

  it('swapSeatsInHall method should return message when second place value is equal to first place value', () => {
    let expected = "Unsuccessful change of seats in the hall.";
    let result = cinema.swapSeatsInHall(5, 5);
    expect(result).to.equal(expected);
  })

  it('swapSeatsInHall method should return message when both input values are incorrect', () => {
    let expected = "Unsuccessful change of seats in the hall.";
    let result = cinema.swapSeatsInHall('bb', 'bb');
    expect(result).to.equal(expected);
  })

  it('swapSeatsInHall method should return message when input values are correct', () => {
    let expected = "Successful change of seats in the hall.";
    let result = cinema.swapSeatsInHall(7, 5);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(20, 15);
    expect(result).to.equal(expected);

    result = cinema.swapSeatsInHall(5, 20);
    expect(result).to.equal(expected);
  })
});

const library = require("./library");
const expect = require("chai").expect;

describe("Library tests", () => {
  it("calcPriceOfBook method should throw error when nameOfBook is not a string", () => {
    expect(() => library.calcPriceOfBook([], 5)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook({}, 5)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook(true, 5)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook(false, 5)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook(4, 5)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook(23.5, 5)).to.throw(Error, "Invalid input");
  });

  it("calcPriceOfBook method should throw error when year is not an integer", () => {
    expect(() => library.calcPriceOfBook("Paf", "Viki")).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook("Paf", true)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook("Paf", false)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook("Paf", 35.6)).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook("Paf", [])).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook("Paf", {})).to.throw(Error, "Invalid input");
    expect(() => library.calcPriceOfBook("Paf", "5")).to.throw(Error, "Invalid input");
  });

  it("calcPriceOfBook method should return exact message when params are valid and year is after 1980", () => {
    let result = library.calcPriceOfBook("Paf", 2000);
    let expected = `Price of Paf is 20.00`;
    expect(result).to.equal(expected);

    result = library.calcPriceOfBook("Paf", 1981);
    expected = `Price of Paf is 20.00`;
    expect(result).to.equal(expected);
  });

  it("calcPriceOfBook method should return exact message when params are valid and year is less than or equal to 1980", () => {
    let result = library.calcPriceOfBook("Paf", 1979);
    let expected = `Price of Paf is 10.00`;
    expect(result).to.equal(expected);

    result = library.calcPriceOfBook("Paf", 1800);
    expected = `Price of Paf is 10.00`;
    expect(result).to.equal(expected);
  });

  it("findBook method should throw Error when empty arrays is passed", () => {
    expect(() => library.findBook([], "Paf")).to.throw(Error, "No books currently available");
  });

  it("findBook method should return message when params are valid and the book is found", () => {
    let result = library.findBook(["Paf", "Viki", "Emre"], "Paf");
    let expected = "We found the book you want.";
    expect(result).to.equal(expected);

    result = library.findBook(["Paf"], "Paf");
    expect(result).to.equal(expected);
  });

  it("findBook method should return message when params are valid and the book is not found", () => {
    let result = library.findBook(["Paf", "Viki", "Emre"], "Ivan");
    let expected = "The book you are looking for is not here!";
    expect(result).to.equal(expected);

    result = library.findBook(["Paf"], "Ivan");
    expect(result).to.equal(expected);
  });

  it("arrangeTheBooks method should throw Error when count is not an integer", () => {
    expect(() => library.arrangeTheBooks(35.6)).to.throw(Error, "Invalid input");
    expect(() => library.arrangeTheBooks([])).to.throw(Error, "Invalid input");
    expect(() => library.arrangeTheBooks({})).to.throw(Error, "Invalid input");
    expect(() => library.arrangeTheBooks(true)).to.throw(Error, "Invalid input");
    expect(() => library.arrangeTheBooks(false)).to.throw(Error, "Invalid input");
    expect(() => library.arrangeTheBooks("false")).to.throw(Error, "Invalid input");
  });

  it("arrangeTheBooks method should throw Error when count is less than zero", () => {
    expect(() => library.arrangeTheBooks(-1)).to.throw(Error, "Invalid input");
    expect(() => library.arrangeTheBooks(-20)).to.throw(Error, "Invalid input");
    expect(() => library.arrangeTheBooks(0)).to.throw(Error, "Invalid input");
  });

  it("arrangeTheBooks method should return message when count of books is bigger than or equal to available space", () => {
    let result = library.arrangeTheBooks(5);
    let expected = "Great job, the books are arranged.";
    expect(result).to.equal(expected);

    result = library.arrangeTheBooks(39);
    expect(result).to.equal(expected);

    result = library.arrangeTheBooks(40);
    expect(result).to.equal(expected);
  });

  it("arrangeTheBooks method should return message when count of books is bigger than available space", () => {
    let result = library.arrangeTheBooks(41);
    let expected = "Insufficient space, more shelves need to be purchased.";
    expect(result).to.equal(expected);

    result = library.arrangeTheBooks(50);
    expect(result).to.equal(expected);
  });
});

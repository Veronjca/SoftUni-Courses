const companyAdministration = require("./companyAdministration");
const expect = require("chai").expect;

describe("Company administration tests", () => {
  it("hiringEmployee method should throw error when passed position is different from Programmer", () => {
    expect(() => companyAdministration.hiringEmployee("Engineer")).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee([])).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee({})).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee(true)).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee(false)).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee(5)).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee(5.5)).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee("5")).to.throw(Error, `We are not looking for workers for this position.`);
    expect(() => companyAdministration.hiringEmployee("programmer")).to.throw(Error, `We are not looking for workers for this position.`);
  });

  it("hiringEmployee method should return message when years of expirience is bigger than or equal to 3", () => {
    let result = companyAdministration.hiringEmployee("Viki", "Programmer", 4);
    let expected = `Viki was successfully hired for the position Programmer.`;
    expect(result).to.equal(expected);

    result = companyAdministration.hiringEmployee("Viki", "Programmer", 3);
    expect(result).to.equal(expected);
  });

  it("hiringEmployee method should return message when years of expirience is less than 3", () => {
    let result = companyAdministration.hiringEmployee("Viki", "Programmer", 2);
    let expected = `Viki is not approved for this position.`;
    expect(result).to.equal(expected);

    result = companyAdministration.hiringEmployee("Viki", "Programmer", 0);
    expect(result).to.equal(expected);
  });

  it("calculateSalary method should throw error when hours is not a number", () => {
    expect(() => companyAdministration.calculateSalary("5")).to.throw(Error, "Invalid hours");
    expect(() => companyAdministration.calculateSalary("Paf")).to.throw(Error, "Invalid hours");
    expect(() => companyAdministration.calculateSalary({})).to.throw(Error, "Invalid hours");
    expect(() => companyAdministration.calculateSalary([])).to.throw(Error, "Invalid hours");
    expect(() => companyAdministration.calculateSalary(true)).to.throw(Error, "Invalid hours");
    expect(() => companyAdministration.calculateSalary(false)).to.throw(Error, "Invalid hours");
    expect(() => companyAdministration.calculateSalary("125false")).to.throw(Error, "Invalid hours");
  });

  it("calculateSalary method should throw error when hours is less than zero", () => {
    expect(() => companyAdministration.calculateSalary(-1)).to.throw(Error, "Invalid hours");
    expect(() => companyAdministration.calculateSalary(-10)).to.throw(Error, "Invalid hours");
  });

  it("calculateSalary method should work properly when passed param is correct", () => {
    let result = companyAdministration.calculateSalary(161);
    let expected = 3415;
    expect(result).to.equal(expected);

    result = companyAdministration.calculateSalary(200);
    expected = 4000;
    expect(result).to.equal(expected);

    result = companyAdministration.calculateSalary(159);
    expected = 2385;
    expect(result).to.equal(expected);

    result = companyAdministration.calculateSalary(160);
    expected = 2400;
    expect(result).to.equal(expected);

    result = companyAdministration.calculateSalary(100);
    expected = 1500;
    expect(result).to.equal(expected);

    result = companyAdministration.calculateSalary(0);
    expected = 0;
    expect(result).to.equal(expected);
  });

  it("firedEmployee method should throw error when employees param is not an array", () => {
    expect(() => companyAdministration.firedEmployee({}, 5)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee(false, 5)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee(5, 5)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee(true, 5)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee(5.5, 5)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee("fired", 5)).to.throw(Error, "Invalid input");
  });

  it("firedEmployee method should throw error when index param is not an integer", () => {
    expect(() => companyAdministration.firedEmployee([], 1.1)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], 0.0)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], 'vvv')).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], '5')).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], [])).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], {})).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], true)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], false)).to.throw(Error, "Invalid input");
  });

  it("firedEmployee method should throw error when index param is less than zero", () => {
    expect(() => companyAdministration.firedEmployee([], -1)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee([], -10)).to.throw(Error, "Invalid input");
  });

  it("firedEmployee method should throw error when index param is bigger than or equal to employees length", () => {
    expect(() => companyAdministration.firedEmployee(["Paf", "Viki", "Emre"], 3)).to.throw(Error, "Invalid input");
    expect(() => companyAdministration.firedEmployee(["Paf", "Viki", "Emre"], 4)).to.throw(Error, "Invalid input");
  });

  it("firedEmployee method should work properly when passed params are correct", () => {
    let actual = companyAdministration.firedEmployee(["Paf", "Emre", "Viki"], 1);
    let expected = "Paf, Viki";
    expect(actual).to.equal(expected);

    actual = companyAdministration.firedEmployee(["Paf", "Emre", "Viki"], 0);
    expected = "Emre, Viki";
    expect(actual).to.equal(expected);

    actual = companyAdministration.firedEmployee(["Paf", "Emre", "Viki"], 2);
    expected = "Paf, Emre";
    expect(actual).to.equal(expected);
  });
});

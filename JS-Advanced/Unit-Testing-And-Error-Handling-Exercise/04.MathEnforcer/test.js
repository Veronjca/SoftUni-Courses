const mathEnforcer = require('./mathEnforcer');
const expect = require('chai').expect;

describe('Add five method tests', () => {
    it('Should return undefined when passed parameter is not a number', () => {
        let addFive = mathEnforcer.addFive;
        expect(addFive('vvv')).to.be.undefined;
        expect(addFive([])).to.be.undefined;
        expect(addFive({})).to.be.undefined;
        expect(addFive(true)).to.be.undefined;
    });

    it('Should work properly when passed parameter is correct', () => {
        let addFive = mathEnforcer.addFive;
        expect(addFive(5)).to.equal(10);
        expect(addFive(23.5)).to.equal(28.5);
        expect(addFive(-1)).to.equal(4);
        expect(addFive(0)).to.equal(5);
    });
});

describe('Subtract ten method tests', () => {
    it('Should return undefined when passed parameter is not correct', () => {
        let subtractTen = mathEnforcer.subtractTen;
        expect(subtractTen('vvv')).to.be.undefined;
        expect(subtractTen([])).to.be.undefined;
        expect(subtractTen({})).to.be.undefined;
        expect(subtractTen(true)).to.be.undefined;
    });

    it('Should work properly when passed parameter is correct', () => {
        let subtractTen = mathEnforcer.subtractTen;
        expect(subtractTen(5)).to.equal(-5);
        expect(subtractTen(23.5)).to.equal(13.5);
        expect(subtractTen(-1)).to.equal(-11);
        expect(subtractTen(0)).to.equal(-10);
    });
})

describe('Sum method tests', () => {
    it('Sum should return undefined when passed parameters are not correct', () => {
        let sum = mathEnforcer.sum;
        expect(sum('vv', 'vv')).to.be.undefined;
        expect(sum([], [])).to.be.undefined;
        expect(sum({}, {})).to.be.undefined;
        expect(sum(true, false)).to.be.undefined;
        expect(sum(10, false)).to.be.undefined;
        expect(sum('blah', 10)).to.be.undefined;
    });
    it('Should work properly when passed parameters are correct', () => {
        let sum = mathEnforcer.sum;
        expect(sum(5, 5)).to.equal(10);
        expect(sum(10.5, 10.5)).to.equal(21);
        expect(sum(-5, -5)).to.equal(-10);
        expect(sum(0, 0)).to.equal(0);

    })
})
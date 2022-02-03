const lookupChar = require('./charLookUp');
const expect = require('chai').expect;

it('Should return undefined when first parameter is not a string', () => {
    expect(lookupChar([], 2)).to.be.undefined;
    expect(lookupChar(2, 2)).to.be.undefined;
    expect(lookupChar({}, 2)).to.be.undefined;
    expect(lookupChar(true, 2)).to.be.undefined;
    expect(lookupChar(23.5, 2)).to.be.undefined;
});

it('Should return undefined when second parameter is not an integer', () => {
    expect(lookupChar('vvvv', true)).to.be.undefined;
    expect(lookupChar('vvvv', 23.5)).to.be.undefined;
    expect(lookupChar('vvvv', 'bb')).to.be.undefined;
    expect(lookupChar('vvvv', [])).to.be.undefined;
    expect(lookupChar('vvvv', {})).to.be.undefined;
    // expect(lookupChar('vvvv', 2.5)).to.be.undefined;

});

it('Should return undefined when both parameters are not correct', () => {
    expect(lookupChar([], true)).to.be.undefined;
});

it('Should return message when index is incorrect', () => {
    let expected = 'Incorrect index';
    expect(lookupChar('vvvv', 10)).to.equal(expected);
    expect(lookupChar('vvvv', -1)).to.equal(expected);
    expect(lookupChar('vvvv', 4)).to.equal(expected);
});

it('Should work properly when both parameters are correct', () => {
    let expected = 'v';
    expect(lookupChar('vvvv', 2)).to.equal(expected);
    expect(lookupChar('vvvv', 0)).to.equal(expected);
    expect(lookupChar('vvvv', 3)).to.equal(expected);
    let second = 'b';
    expect(lookupChar('abc', 1)).to.equal(second);
});
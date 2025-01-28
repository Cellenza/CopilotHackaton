const MultiplesOf3or5 = require('./MultiplesOf3or5');

test('givenNegativeInput_return0', () => {
    const multiplesOf3or5 = new MultiplesOf3or5(-1);
    expect(multiplesOf3or5.sum()).toBe(0);
});

test('given0_return0', () => {
    const multiplesOf3or5 = new MultiplesOf3or5(0);
    expect(multiplesOf3or5.sum()).toBe(0);
});

test('given4_return3', () => {
    const multiplesOf3or5 = new MultiplesOf3or5(4);
    expect(multiplesOf3or5.sum()).toBe(3);
});

test('given10_return23', () => {
    const multiplesOf3or5 = new MultiplesOf3or5(10);
    expect(multiplesOf3or5.sum()).toBe(23); // 3 + 5 + 6 + 9
});

test('given20_return78', () => {
    const multiplesOf3or5 = new MultiplesOf3or5(20);
    expect(multiplesOf3or5.sum()).toBe(78); // 3 + 5 + 6 + 9 + 10 + 12 + 15 + 18
});

test('given200_return9168', () => {
    const multiplesOf3or5 = new MultiplesOf3or5(200);
    expect(multiplesOf3or5.sum()).toBe(9168); // Sum of multiples of 3 or 5 below 200
});
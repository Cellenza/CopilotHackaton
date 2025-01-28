const Number = require('./Number');

test('given0_resultShouldBe0', () => {
    const num = 0;
    const expectedRes = 0;
    const number = new Number(num);

    const res = number.digitalRoot();

    expect(res).toBe(expectedRes);
});

test('given10_resultShouldBe1', () => {
    const num = 10;
    const expectedRes = 1;
    const number = new Number(num);

    const res = number.digitalRoot();

    expect(res).toBe(expectedRes);
});
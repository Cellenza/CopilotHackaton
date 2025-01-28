const Number = require('./Number');

test('digitalRoot_ShouldReturnExpectedResult', () => {
    const testData = [
        { num: 0, expectedRes: 0 },
        { num: 10, expectedRes: 1 },
        { num: 12345, expectedRes: 6 },
        { num: 9876, expectedRes: 3 },
        { num: 999999999, expectedRes: 9 },
        { num: 123456789, expectedRes: 9 }
    ];

    testData.forEach(({ num, expectedRes }) => {
        const number = new Number(num);
        const res = number.digitalRoot();
        expect(res).toBe(expectedRes);
    });
});
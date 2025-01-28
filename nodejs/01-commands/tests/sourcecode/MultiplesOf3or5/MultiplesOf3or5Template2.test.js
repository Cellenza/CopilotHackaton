const MultiplesOf3or5 = require('./MultiplesOf3or5');

test('givenInput_ReturnExpectedSum', () => {
    const testData = [
        [-1, 0],
        [0, 0],
        [4, 3],
        [10, 23],
        [20, 78],
        [200, 9168]
    ];

    testData.forEach(([input, expectedSum]) => {
        const multiplesOf3or5 = new MultiplesOf3or5(input);
        expect(multiplesOf3or5.sum()).toBe(expectedSum);
    });
});
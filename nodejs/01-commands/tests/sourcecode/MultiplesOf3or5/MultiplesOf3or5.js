class MultiplesOf3or5 {
    constructor(number) {
        this.number = number;
    }

    sum() {
        let sum = 0;
        for (let i = 1; i < this.number; i++) {
            if (i % 3 === 0 || i % 5 === 0) {
                sum += i;
            }
        }
        return sum;
    }
}

module.exports = MultiplesOf3or5;
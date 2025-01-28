class Number {
    constructor(number) {
        this._number = number;
    }

    digitalRoot() {
        let result = 0;
        let number = this._number;

        while (number > 0) {
            result += number % 10;
            number = Math.floor(number / 10);
        }

        if (result > 9) {
            const newNumber = new Number(result);
            result = newNumber.digitalRoot();
        }

        return result;
    }
}

module.exports = Number;
class Year {
    constructor(year) {
        this._year = year;
    }

    isLeapYear() {
        const year = this._year;
        return (year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0);
    }
}

module.exports = Year;
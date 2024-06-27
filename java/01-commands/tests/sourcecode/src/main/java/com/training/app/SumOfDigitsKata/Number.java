package com.training.app.SumOfDigitsKata;

public class Number {
    private long _number;

    public Number(long number) {
        _number = number;
    }

    public long digitalRoot() {
        long result = 0;

        while (_number > 0) {
            result += _number % 10;
            _number = _number / 10;
        }

        if (result > 9) {
            Number number = new Number(result);
            result = number.digitalRoot();
        }

        return result;
    }
}

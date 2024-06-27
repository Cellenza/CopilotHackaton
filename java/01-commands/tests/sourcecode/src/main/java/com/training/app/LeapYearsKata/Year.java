package com.training.app.LeapYearsKata;

public class Year {
    private int _year;

    public Year(int year) {
        _year = year;
    }

    public boolean isLeapYear() {
        if (isYearDivisibleBy(400))
            return true;
        else if (isYearDivisibleBy(4) && !isYearDivisibleBy(100))
            return true;
        return false;
    }

    private boolean isYearDivisibleBy(int toDivideBy) {
        return _year % toDivideBy == 0;
    }
}

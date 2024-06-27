#pragma once
class Year
{
public:
    Year(int year);
    bool IsLeapYear() const;

private:
    int _year;

    bool IsDivisibleBy(int divisor) const;
};


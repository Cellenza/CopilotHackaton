#include "pch.h"
#include "Year.h"

Year::Year(int year)
    : _year(year)
{}

bool Year::IsLeapYear() const
{
    return (IsDivisibleBy(4) && (!IsDivisibleBy(100)) || IsDivisibleBy(400));
}

bool Year::IsDivisibleBy(int divisor) const
{
    return (_year % divisor) == 0;
}
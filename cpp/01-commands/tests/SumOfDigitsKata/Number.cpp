#include "pch.h"
#include "Number.h"

Number::Number(long number)
    : _number(number)
{}

long Number::DigitalRoot()
{
    long result = 0;

    while (_number > 0)
    {
        result += _number % 10;
        _number = _number / 10;
    }

    if (result > 9)
    {
        Number number(result);
        result = number.DigitalRoot();
    }

    return result;
}

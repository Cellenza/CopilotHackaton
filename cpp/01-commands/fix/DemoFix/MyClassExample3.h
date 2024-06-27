#pragma once

class MyClassExample3
{
private:
    double d = 0.0;

public:
    double f()
    {
        return d;
    }

    static double Run()
    {
        const MyClassExample3 example3;
        return example3.f();
    }
};

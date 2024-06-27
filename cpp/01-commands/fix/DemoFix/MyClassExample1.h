#pragma once

class MyClassExample1
{
public:
    virtual int f() = 0;
};

class MyClass2
{
public:
    int f() override
    {
        return 0;
    }
};


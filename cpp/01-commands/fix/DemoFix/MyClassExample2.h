#pragma once

class MyClassExample2
{
public:
    int i;
    void Method()  
    {}
    int GetValue() 
    { 
        return 42; 
    }

    static void Run()
    {
        i = 10;
        Method();
        int value = GetValue();
    }
};


package com.training.app;

interface IList {
    int getCount();
    void setCount(int count);
    void counter();
}

interface ICounter {
    double getCount();
    void setCount(double count);
}

interface IListCounter extends IList, ICounter {}

class MyClass {
    void test(IListCounter x) {
        x.setCount(1);
    }

    public static void main(String[] args) {}
}

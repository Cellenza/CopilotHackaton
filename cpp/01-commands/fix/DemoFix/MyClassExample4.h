#pragma once

class IList
{
public:
    virtual int GetCount() = 0;
    virtual void SetCount(int) = 0;
};

class ICounter
{
public:
    virtual int GetCount() = 0;
    virtual void SetCount(int) = 0;
};

class IListCounter : public IList, public ICounter
{};

int Test(IListCounter& listCounter)
{
    listCounter.SetCount(10);
    return listCounter.GetCount();
}

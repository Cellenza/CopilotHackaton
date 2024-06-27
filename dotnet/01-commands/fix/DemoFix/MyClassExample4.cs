using System;
namespace MyNamespace
{
    interface IList
    {
        int Count
        {
            get;
            set;
        }
        void Counter();
    }
    interface ICounter
    {
        double Count
        {
            get;
            set;
        }
    }

    interface IListCounter : IList, ICounter { }

    class MyClass
    {
        void Test(IListCounter x)
        {
            x.Count = 1;    
        }

        public static void Main() { }
    }
}
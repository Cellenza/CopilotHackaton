using System;
namespace MyNamespace
{
    abstract public class MyClassExample1
    {
        public abstract int f();
    }

    abstract public class MyClass2
    {
        public override int f()   
        {
            return 0;
        }

        public static void Main()
        {
        }
    }
}
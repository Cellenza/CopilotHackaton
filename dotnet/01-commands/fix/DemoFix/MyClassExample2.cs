namespace DemoFix
{
    internal class MyClassExample2
    {
        
        public int i;
        public void Method() { }
        public int Prop
        {
            get
            {
                return 1;
            }
        }

        public static void Main()
        {
            i = 10;
            Method();  
            int p = Prop;   
        }
    }
}

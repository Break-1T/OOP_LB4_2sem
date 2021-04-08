using System;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int c = 0;
            object b = (object) a;
            Console.WriteLine(Equals(a.GetHashCode(),c.GetHashCode()));
        }
    }
}

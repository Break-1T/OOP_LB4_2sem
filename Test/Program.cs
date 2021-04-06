using System;
using System.Threading;

namespace Test
{
    class Program
    {
        static Mutex mutexObj = new Mutex();
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread t = new Thread(Count);
                t.Name = $"Поток: {i}";
                t.Start();
            }
        }

        public static void Count()
        {
            mutexObj.WaitOne();
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
                Thread.Sleep(100);
            }
            mutexObj.ReleaseMutex();
        }
    }
}

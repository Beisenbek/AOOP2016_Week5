using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAndTimer
{
    class Program
    {
        static void Main(string[] args)
        {
            F1();
        }

        private static void F2()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(DoIt2));
            t1.Start("t1");

            Thread t2 = new Thread(new ParameterizedThreadStart(DoIt2));
            t2.Start("t2");

            Console.ReadLine();
            t2.Abort();
        }

        private static void DoIt2(object obj)
        {
            string s = obj as string;
            while (true)
            {
                Console.WriteLine("waiting... from " + s + Thread.CurrentThread.ManagedThreadId);
               // Thread.Sleep(1000);
            }
        }

        private static void F1()
        {
            Timer t = new Timer(new TimerCallback(DoIt));
            t.Change(0, 1000);
            Thread.Sleep(10000);
            Console.WriteLine("main thread");

            Console.ReadLine();
        }

        private static void DoIt(object state)
        {
            Console.WriteLine("waiting...");
        }
    }
}

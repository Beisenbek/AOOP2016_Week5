
using System;

namespace Decorator2
{
    public interface ICompanent
    {
        void Operation();
    }

    public class CompanentA : ICompanent
    {
        public void Operation()
        {
            Console.WriteLine("inside CompanentA");
        }
    }

    public class CompanentB : ICompanent
    {
        public void Operation()
        {
            Console.WriteLine("inside CompanentB");
        }
    }

    public class Decarator : ICompanent
    {
        ICompanent _companent = null;

        public void SetupComponent(ICompanent companent)
        {
            _companent = companent;
        }

        public void Operation()
        {
            _companent.Operation();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Decarator d = new Decarator();

            CompanentA a = new CompanentA();
            CompanentB b = new CompanentB();

            
            while (true)
            {
                string line = Console.ReadLine();

                if (line.Contains("a"))
                {
                    d.SetupComponent(a);
                }
                else {
                    d.SetupComponent(b);
                }

                d.Operation();
            }
        }
    }
}

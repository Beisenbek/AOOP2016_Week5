using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    public class Point
    {
        public int x;
        public int y;
        public DateTime dateTime;

        private static Point instance;

        protected Point()
        {
            x = 10;
            y = 10;
            dateTime = DateTime.Now;
        }


        public static Point Instance()
        {
            lock (instance)
            {
                if (instance == null)
                {
                    instance = new Point();
                }
            }

            return instance;
        }
    }

    class Point2 : Point
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point2 p = Point.Instance() as Point2;
            Point2 p2 = Point.Instance() as Point2;

            Console.WriteLine(string.Format("x = {0}, y = {1}, from date = {2}", p.x, p.y, p.dateTime.ToString("hh:mm:ss:fff")));
            Thread.Sleep(2000);

            Console.WriteLine(string.Format("x = {0}, y = {1}, from date = {2}", p2.x, p2.y, p2.dateTime.ToString("hh:mm:ss:fff")));
    
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MkvCompare
{
    class Controller
    {
        public static void test1()
        {
            Console.WriteLine("Test1");
            Controller.test2();
        }
        private static void test2()
        {
            Console.WriteLine("Test2");
        }
    }
}

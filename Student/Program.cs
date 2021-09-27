using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            List<Student> stlist = new List<Student>() { new Student("Ирина"), new Student("Инна"), new Student("Имма") };
            Menu menu = new Menu();
            menu.MenuMain(stlist);
        }
    }
}

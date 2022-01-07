using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAiPLabOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа A, B, C, D: ");
            int A = Convert.ToInt32(Console.ReadLine());
            int B = Convert.ToInt32(Console.ReadLine());
            int C = Convert.ToInt32(Console.ReadLine());
            int D = Convert.ToInt32(Console.ReadLine());
            if ((A>B) && (B>C) && (C>D))
            {
                Console.WriteLine("Убывающую");
            }
            else
            {
                Console.WriteLine("Не убывающую");
            }
            Console.ReadLine();
        }
    }
}

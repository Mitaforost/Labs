using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAiPLabTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10 Вариант. Даны числа A, B и C. A является делителем, B - делимым, а C, в свою очередь,
            // является конечной степенью числа A.Вычислить сумму частных от А и B для 
            // каждого возведения в степень числа A и вывести в консоль
            double A, B, C;
            double X = 0, Sum = 0;
            Console.WriteLine("Введите число A делитель: ");
            A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число B делимое: ");
            B = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите число C конечная степень числа A: ");
            C = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < C; i++)
            {

                X = B / Math.Pow(A, i);
                Sum = Sum + X;
            }
            Console.WriteLine(Sum);
            Console.ReadLine();
        }
    }
}

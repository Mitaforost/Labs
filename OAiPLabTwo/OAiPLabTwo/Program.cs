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
            int A, B;
            do
            {
                Console.WriteLine("Введите число A делитель: ");
                A = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число B делимое: ");
                B = Convert.ToInt32(Console.ReadLine());

                if ((A > B && A % B == 0) || (B > A && B % A == 0) || B == A)
                {
                    Console.WriteLine("Да, одно из чисел является делителем другого");
                }
                else
                {
                    Console.WriteLine("Нет, ни одно из чисел не является делителем другого");
                }
            } while (A >= 0);
            Console.ReadLine();
        }
    }
}

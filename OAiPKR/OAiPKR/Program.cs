using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAiPKR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = -n; i < n; i++)
            {
                if (i / 100 % 2 == 0)
                {
                    if (i / 100 != 0)
                    {
                        Console.Write(i + ", ");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}

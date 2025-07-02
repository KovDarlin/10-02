using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] list = { -34, -89, -21, -70, 7, 14, -12, -70, 89, 7, 7, -70 };

        var negative = list.Where(n => n < 0).Distinct().OrderBy(n => n).ToArray();

        Action Print = () =>
        {
            Console.WriteLine("Unique negative numbers:");
            foreach (var n in negative)
                Console.WriteLine(n);
        };

        Print();
    }
}

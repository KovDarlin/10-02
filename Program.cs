using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] list = { -34, 89, 21, 70, 7, 14, 12 };
        Func<int, int, int> result = (min,max) => list.Count(x => x >= min && x <= max);
        Console.WriteLine("(-30, 90) :" + result(-30,90));
        Console.WriteLine("(5, 30) :" + result(5, 30));

    }
}
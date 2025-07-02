using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] list = { 34, 89, 21, 70, 7, 14, 12 };
        Func<int, int> result = res => list.Count(x => x % res == 0);
        Console.WriteLine("7 :" + result(7));
        Console.WriteLine("3 :" + result(3));
        Console.WriteLine("2 :" + result(2));
    }
}
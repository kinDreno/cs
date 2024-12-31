using System;

namespace HelloWorld;
static class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 4, 6, 6, 10, 0 };
        int getLast = Array.LastIndexOf(arr, 0);
        Console.WriteLine($"The last index that the value was seen is in the index of {getLast}!");
        Array.Sort(arr);
        foreach (int ar in arr)
        {
            Console.WriteLine(ar);
        }
    }
}

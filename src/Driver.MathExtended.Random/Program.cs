using MatxExtended.Random;
using System;

namespace Driver.MathExtended.Random
{
    class Program
    {
        static void Main(string[] args)
        {
            int factor = 4096 * 4096;
            var ranmar = new Ranmar(1802, 9373);

            for (int i = 0; i < 20006; i++)
            {
                int generatedNumber = ranmar.Next(factor);
                if (i < 20000) continue;
                Console.WriteLine($"{i + 1}. {generatedNumber}");
            }

            Console.WriteLine($"Double = {ranmar.NextDouble()}");

            Console.ReadKey();
        }
    }
}
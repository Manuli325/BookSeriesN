using System;

namespace BookSeriesPotterKata
{
    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Input.Process();
                Console.Write("Please press any key to continue ");

            } while (!"q".Equals(Console.ReadLine(), StringComparison.CurrentCultureIgnoreCase));
        }
    }
}

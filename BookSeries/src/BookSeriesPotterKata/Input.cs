using BookSeriesPotterKata.Enumerations;
using BookSeriesPotterKata.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSeriesPotterKata
{
    internal static class Input
    {
        public static void Process()
        {
            Console.WriteLine();
            

            var basket = new ShoppingBag();

            foreach (Enumerations.Enum bookVolume in System.Enum.GetValues(typeof(Enumerations.Enum)))
            {
                Console.Write($"Book Series {bookVolume.ToString()} : ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int quantity))
                {
                    basket.AddBooks(bookVolume, quantity);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }


            Console.WriteLine();
            Console.WriteLine($"Total price of the basket : {basket.TotalPrice}");
            Console.WriteLine("Book combinations in the basket :-");
            Console.WriteLine(basket.PrintBookSets());
        }
    }
}

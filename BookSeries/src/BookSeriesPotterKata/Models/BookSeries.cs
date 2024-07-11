using BookSeriesPotterKata.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSeriesPotterKata.Models
{
    internal class BookSeries
    {
        private readonly List<Book> books = new List<Book>();
        private readonly DiscountCalculation discounts = new DiscountCalculation();

        public double Price
        {
            get
            {
                var discount = discounts.GetDiscount(books.Count);
                return books.Sum(x => x.BookPrice) * discount;
            }
        }

        public bool Contains(Book book)
        {
            return books.Exists(x => x.BookVolume == book.BookVolume);
        }

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }

        public string PrintBookSet()
        {
            string output = null;
            foreach (Enumerations.Enum bookVolume in System.Enum.GetValues(typeof(Enumerations.Enum)))
            {
                string temp = books.Exists(x => x.BookVolume == bookVolume) ? "1" : "0";
                output = output == null ? temp : $"{output}, {temp}";
            }
            return output;
        }
    }
}

using BookSeriesPotterKata.Enumerations;
using BookSeriesPotterKata.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookSeriesPotterKata.Services
{
    public class ShoppingBag
    {
        private readonly List<BookSeries> bookSets = new List<BookSeries>();

        public double TotalPrice
        {
            get
            {
                return bookSets.Sum(x => x.Price);
            }
        }

        public void AddBook(Book book)
        {
            var availableBookSets = bookSets.Where(x => !x.Contains(book));

            if (availableBookSets != null && availableBookSets.Count() != 0)
            {
                ChooseOptimalBookSet(availableBookSets, book).AddBook(book);
            }
            else
            {
                var newBookSet = new BookSeries();
                newBookSet.AddBook(book);
                bookSets.Add(newBookSet);
            }
        }

        public void AddBooks(Enumerations.Enum bookVolume, int quantity)
        {
            for (int i = 1; i <= quantity; i++)
            {
                AddBook(new Book(bookVolume));
            }
        }

        public void AddBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                AddBook(book);
            }
        }

        public string PrintBookSets()
        {
            string output = string.Empty;
            foreach (var bookSet in bookSets)
            {
                output = output + bookSet.PrintBookSet() + Environment.NewLine;
            }
            return output;
        }

        private BookSeries ChooseOptimalBookSet(IEnumerable<BookSeries> availableBookSets, Book book)
        {
            BookSeries optimalBookSet = null;
            double totalPrice = double.MaxValue;

            foreach (var bookSet in availableBookSets)
            {
                bookSet.AddBook(book);
                if (TotalPrice < totalPrice)
                {
                    totalPrice = TotalPrice;
                    optimalBookSet = bookSet;
                }
                bookSet.RemoveBook(book);
            }

            return optimalBookSet;
        }
    }
}

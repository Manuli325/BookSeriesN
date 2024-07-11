using BookSeriesPotterKata.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookSeriesPotterKata.Models
{
    public class Book
    {
        public double BookPrice { get; } = 8;
        public Enumerations.Enum BookVolume { get; }

        public Book(Enumerations.Enum bookVolume)
        {
            BookVolume = bookVolume;
        }
    }
}

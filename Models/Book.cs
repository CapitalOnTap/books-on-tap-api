
using System;

namespace Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public string Thumbnail { get; set; }
        public string ISBN { get; set; }
    }

}

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
        public bool IsInStock { get; set; }
        public string Preview { get; set; }
        public string Link { get; set; }

    }

}
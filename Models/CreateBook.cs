
using System;

namespace Models
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public string Thumbnail { get; set; }
        public string ISBN { get; set; }
    }
}
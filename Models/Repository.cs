using System;
using System.Collections.Generic;

namespace Models
{
    public class Repository : IRepository
    {
        public List<Book> Books { get; set; }

        public Repository(List<Book> books)
        {
            Books = books;
        }

        public Book GetById(Guid id)
        {
            return Books.Find(x => x.Id == id);
        }

        public Book GetByAuthorId(Guid authorId)
        {
            return Books.Find(x => x.Author.Id == authorId);
        }

        public void Add(Book book)
        {
            book.Id = Guid.NewGuid();
            Books.Add(book);
        }

        public IEnumerable<Book> GetAll()
        {
            return Books.ToArray();
        }

        public Book Find(Book book)
        {
            return Books.Find(x => x.Title == book.Title);
        }
    }
}
using System;
using System.Collections.Generic;

namespace Models
{
    public class Repository : IRepository
    {
        private List<Book> Books { get; set; }
        private List<Author> Authors { get; set; }

        public Repository(List<Book> books, List<Author> authors)
        {
            Books = books;
            Authors = authors;
        }

        public Book GetById(Guid id)
        {
            return Books.Find(x => x.Id == id);
        }

        public Author GetAuthorById(Guid authorId)
        {
            return Authors.Find(x => x.Id == authorId);
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

        public void Delete(Book book)
        {
            Books.Remove(book);
        }

        public Book Update(Book bookToUpdate)
        {
            var index = Books.IndexOf(bookToUpdate);

            Books[index] = bookToUpdate;

            return Books[index];
        }

        public Book GetByISBN(string isbn)
        {
            return Books.Find(x => x.ISBN == isbn);
        }
    }
}
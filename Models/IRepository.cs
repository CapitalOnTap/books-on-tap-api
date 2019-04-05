using System;
using System.Collections.Generic;

namespace Models
{
    public interface IRepository
    {
        Book GetById(Guid id);
        Author GetAuthorById(Guid authorId);
        void Add(Book book);
        IEnumerable<Book> GetAll();
        Book Find(Book book);
        void Delete(Book book);
        Book Update(Book book);
        Book GetByISBN(string isbn);
    }
}
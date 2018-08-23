using System;
using System.Collections.Generic;

namespace Models
{
    public interface IRepository
    {
        Book GetById(Guid id);

        Book GetByAuthorId(Guid authorId);

        void Add(Book book);

        IEnumerable<Book> GetAll();

        Book Find(Book book);
    }
}
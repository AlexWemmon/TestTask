using BookAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Domain.Repositories.Abstract
{
    public interface IBooksRepository
    {
        IQueryable<Book> GetAllBooks();
        Book GetBookById(Guid? id);
        void SaveBook(Book book);
        void DeleteBook(Guid ?id);
    }
}

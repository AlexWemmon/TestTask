using Microsoft.EntityFrameworkCore;
using StoreApp.Domain.Entities;
using StoreApp.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace StoreApp.Domain.Repositories.EntityFramework
{
    public class EFBooksRepository : IBooksRepository
    {
        private AppDbContext _context;
        public EFBooksRepository()
        {

        }
        public EFBooksRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> GetAllBooks()
        {
            return _context.Books;
        }
        public Book GetBookById(Guid? id)
        {
            return _context.Books.Find(id.Value);
        }
        public void DeleteBook(Book book)
        {
            _context.Remove(book);
            _context.SaveChanges();
        }
        public void SaveBook(Book book)
        {
            if (book == default) _context.Entry(book).State = EntityState.Added;
            else _context.Entry(book).State = EntityState.Modified;
            _context.Add(book);
            _context.SaveChanges();
        }
    }
}

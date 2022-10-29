using Microsoft.EntityFrameworkCore;
using BookAPI.Domain.Entities;
using BookAPI.Domain.Repositories.Abstract;
using System;
using System.Linq;

namespace BookAPI.Domain.Repositories.EntityFramework
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
        public void DeleteBook(Guid? id)
        {
            if (id.HasValue)
            {
                _context.Remove(new Book() { Id = id.Value });
                _context.SaveChanges();
            }
        }
        public void SaveBook(Book book)
        {
            var isExistedBook = GetBookById(book.Id) != null ? true: false;
            if (!isExistedBook) _context.Entry(book).State = EntityState.Added;
            else
            {
                var existedBook = GetBookById(book.Id);
                existedBook.Name = book.Name;
                existedBook.Description = book.Description;
                existedBook.Price = book.Price;
                _context.Entry(existedBook).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}

using BookAPI.Domain.Entities;
using BookAPI.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BookAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookAPIController : ControllerBase
    {
        private IBooksRepository _booksRepository;

        public BookAPIController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public IEnumerable<Book> GetBook() => _booksRepository.GetAllBooks();

        [HttpGet("{Id}")]
        public ActionResult<Book> GetBookById(Guid ?Id) 
        {
            if (!Id.HasValue) return BadRequest("Неправильное значение Id - должно быть не пустое");
            return Ok(_booksRepository.GetBookById(Id)); 
        }
        [HttpPost]
        public Book PostBook([FromBody] Book book)
        {
            _booksRepository.SaveBook(book);
            return _booksRepository.GetBookById(book.Id);
        }
        [HttpPut]
        public Book PutBook([FromBody] Book book) 
        { 
            _booksRepository.SaveBook(book);
            return _booksRepository.GetBookById(book.Id);
        }

        [HttpDelete("{bookId}")]
        public void DeleteBook(Guid ?bookId) 
        { 
            _booksRepository.DeleteBook(bookId); 
        }
    }
}

using BooksApiWithEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BooksApiWithEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDbContext _context;

        public BooksController(BooksDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        [HttpGet]
        [Route("/seatch/{searchText}")]
        public List<Book> SearchBooksByTitle(string searchText) 
        {
            return _context.Books.Where(book => book.Title.ToLower().Contains(searchText)).ToList();
        }

        [HttpPost]
        public Book AddNewBook(Book newbook)
        {
            _context.Books.Add(newbook);
            _context.SaveChanges();
            var addedBook = _context.Books.Where(book => book.Title.Contains(newbook.Title)).FirstOrDefault();
            return addedBook;
        }

        [HttpPut]
        public Book updateBook(Book updatedBook)
        {
            _context.Books.Update(updatedBook);
            _context.SaveChanges();
            var book = _context.Books.Where(book => book.BookId == updatedBook.BookId).FirstOrDefault();
            return book;
        }
    }
}

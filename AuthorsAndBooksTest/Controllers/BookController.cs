using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Entities;
using AuthorsAndBooksTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AuthorsAndBooksTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookRepository _bookService;

        public BookController(ILogger<BookController> logger, IBookRepository bookService)
        {
            _logger = logger;
            _bookService = bookService ?? throw new ArgumentException(nameof(bookService));
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.Get();
        }


        [Route("GetBooksByAuthorAndDate")]
        [HttpPost]
        public IEnumerable<Book> GetBooksByFilters(BooksByAuthor request)
        {
            return _bookService.GetBooksByFilters(request);
        }
    }
}

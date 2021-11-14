using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Context;
using AuthorsAndBooksTest.Entities;
using AuthorsAndBooksTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
            //var httpClient = new HttpClient();
            //var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");

            //var boksList = JsonConvert.DeserializeObject<List<Book>>(json);

            //return Ok(boksList);
            return _bookService.Get();
        }


        [Route("GetBooksByAuthorAndDate")]
        [HttpPost]
        public IEnumerable<Book> GetBooksByFilters(BooksByAuthor request)
        {
            //         var httpClient = new HttpClient();

            //         var jsonBooks = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");

            //         var booksList = JsonConvert.DeserializeObject<List<Book>>(jsonBooks);

            //         if(request.IdBook != null)
            //{
            //             var idBook = Int32.Parse(request.IdBook);
            //             var booksFilterByAuthor = booksList.Where(b => b.PublishDate >= request.StartDate && b.PublishDate <= request.EndDate && b.Id == idBook);
            //             return Ok(booksFilterByAuthor);
            //         }

            //         var booksFilter = booksList.Where(b => b.PublishDate >= request.StartDate && b.PublishDate <= request.EndDate);

            //         return Ok(booksFilter);
            //     }
            return _bookService.GetBooksByFilters(request);
        }
    }
}

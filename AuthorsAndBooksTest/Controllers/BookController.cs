using AuthorsAndBooks.BindingModel;
using AuthorsAndBooksTest.BindingModel;
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
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");

            var boksList = JsonConvert.DeserializeObject<List<Book>>(json);

            return Ok(boksList);
        }

        [HttpPost]
        public async Task<IActionResult> GetBookById([FromBody] Book request)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");

            var boksList = JsonConvert.DeserializeObject<List<Book>>(json);

            return Ok(boksList);
        }

        [Route("GetBooksByAuthorAndDate")]
        [HttpPost]
        public async Task<IActionResult> GetBooksByFilters(BooksByAuthor request)
        {
            var httpClient = new HttpClient();

            var jsonBooks = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");

            var booksList = JsonConvert.DeserializeObject<List<Book>>(jsonBooks);

            if(request.IdBook != null)
			{
                var idBook = Int32.Parse(request.IdBook);
                var booksFilterByAuthor = booksList.Where(b => b.PublishDate >= request.StartDate && b.PublishDate <= request.EndDate && b.Id == idBook);
                return Ok(booksFilterByAuthor);
            }

            var booksFilter = booksList.Where(b => b.PublishDate >= request.StartDate && b.PublishDate <= request.EndDate);

            return Ok(booksFilter);
        }
    }
}

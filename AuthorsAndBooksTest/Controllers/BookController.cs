using AuthorsAndBooks.BindingModel;
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
    }
}

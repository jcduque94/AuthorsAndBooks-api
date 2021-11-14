
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
	/// <summary>
	/// Authors Controller
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : Controller
	{
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorRepository _authorService;
        
        public AuthorController(ILogger<AuthorController> logger, IAuthorRepository authorService)
        {
            _logger = logger;
            _authorService = authorService ?? throw new ArgumentException(nameof(authorService));
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            //         var httpClient = new HttpClient();
            //         var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Authors");

            //var authorsList = JsonConvert.DeserializeObject<List<Author>>(json);

            //return Ok(authorsList);
            return _authorService.Get();
        }
    }
}


using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Context;
using AuthorsAndBooksTest.Entities;
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
	public class AuthorController : ControllerBase
	{
        private readonly ILogger<AuthorController> _logger;
        private readonly AppDbContext context;
        public AuthorController(ILogger<AuthorController> logger, AppDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            //         var httpClient = new HttpClient();
            //         var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Authors");

            //var authorsList = JsonConvert.DeserializeObject<List<Author>>(json);

            //return Ok(authorsList);
            return context.Author.ToList();
        }
    }
}

﻿using AuthorsAndBooks.BindingModel;
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
	/// <summary>
	/// Authors Controller
	/// </summary>
	[Route("[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Authors");

			var authorsList = JsonConvert.DeserializeObject<List<Author>>(json);

			return Ok(authorsList);
        }
    }
}

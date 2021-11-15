
using AuthorsAndBooksTest.Entities;
using AuthorsAndBooksTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

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
            return _authorService.Get();
        }
    }
}

using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Controllers
{
	/// <summary>
	/// Authors Controller
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly ILogger<UserController> _logger;
		private readonly IUserRepository _userService;

		public UserController(ILogger<UserController> logger, IUserRepository userService)
		{
			_logger = logger;
			_userService = userService ?? throw new ArgumentException(nameof(userService));
		}

		[Route("Authentication")]
		[HttpPost]
		public async Task<IActionResult> Authentication(User request)
		{
			var authentication = await _userService.Authentication(request);

			return Ok(authentication);
		}
	}
}

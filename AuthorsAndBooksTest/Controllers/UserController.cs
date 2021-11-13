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
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly ILogger<UserController> _logger;

		public UserController(ILogger<UserController> logger)
		{
			_logger = logger;
		}

		[Route("Authentication")]
		[HttpPost]
		public async Task<IActionResult> Authentication(User request)
		{
			var httpClient = new HttpClient();
			var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Users");

			var users = JsonConvert.DeserializeObject<List<User>>(json);
			var userLogin = users.Where(u => u.UserName.Equals(request.UserName) && u.Password.Equals(request.Password)).FirstOrDefault();
			if(userLogin == null)
			{
				return Ok(false);
			}

			return Ok(true);
		}
	}
}

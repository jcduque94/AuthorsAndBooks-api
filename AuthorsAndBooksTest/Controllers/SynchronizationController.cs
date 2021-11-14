using AuthorsAndBooksTest.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Controllers
{
	/// <summary>
	/// Authors Controller
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class SynchronizationController : Controller
	{
		private readonly ILogger<AuthorController> _logger;
		private readonly ISynchronizationRepository _synchronizationService;
		public SynchronizationController(ILogger<AuthorController> logger, ISynchronizationRepository synchronizationService)
		{
			_logger = logger;
			_synchronizationService = synchronizationService ?? throw new ArgumentException(nameof(synchronizationService));
		}

		[HttpGet]
		public async Task<IActionResult> SynchronizationDataDB()
		{
			var synchronization = await _synchronizationService.Synchronization();
			return Ok(synchronization);
		}
	}
}

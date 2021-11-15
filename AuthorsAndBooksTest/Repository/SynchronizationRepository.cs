using AuthorsAndBooksTest.Context;
using AuthorsAndBooksTest.Entities;
using AuthorsAndBooksTest.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository
{
	public class SynchronizationRepository: ISynchronizationRepository
	{
		private readonly AppDbContext context;
		public SynchronizationRepository(AppDbContext context)
		{
			this.context = context;
		}

		public async Task<Boolean> Synchronization()
		{
			var httpClient = new HttpClient();
			var auhtorsJson = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Authors");
			var booksJson = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Books");
			var authorsList = JsonConvert.DeserializeObject<List<Author>>(auhtorsJson);
			var boksList = JsonConvert.DeserializeObject<List<Book>>(booksJson);

			context.Author.RemoveRange(context.Author);
			context.Book.RemoveRange(context.Book);
			context.Book.AddRange(boksList);
			context.SaveChanges();
			context.Author.AddRange(authorsList);
			context.SaveChanges();
			return true;
		}
	}
}

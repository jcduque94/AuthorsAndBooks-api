using AuthorsAndBooksTest.Context;
using AuthorsAndBooksTest.Entities;
using AuthorsAndBooksTest.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

			//Author author1 = new Author();
			//author1.Id = 1;
			//author1.IdBook = 3;
			//author1.FirstName = "Nicolas";
			//author1.LastName = "Galicia";

			//var now = DateTime.UtcNow.AddHours(-5);
			//now = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);
			//Book book1 = new Book();
			//book1.Id = 3;
			//book1.Title = "Titulo no definido";
			//book1.Description = "Descripcion no definida";
			//book1.PageCount = 500;
			//book1.Excerpt = "Excerpt";
			//book1.PublishDate = now;
			//IList< Author> ListAuthors = new List<Author>();
			//IList<Book> ListBooks = new List<Book>();

			//ListAuthors.Add(author1);
			//ListBooks.Add(book1);
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

using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Context;
using AuthorsAndBooksTest.Entities;
using AuthorsAndBooksTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository
{
	public class BookRepository : IBookRepository
	{
		private readonly AppDbContext context;
		public BookRepository(AppDbContext context)
		{
			this.context = context;
		}

		public IEnumerable<Book> Get()
		{
			return context.Book.ToList();
		}

		public IEnumerable<Book> GetBooksByFilters(BooksByAuthor filters)
		{
			if (filters.IdBook != null)
			{
				var idBook = Int32.Parse(filters.IdBook);
				return context.Book.Where(b => b.PublishDate >= filters.StartDate && b.PublishDate <= filters.EndDate && b.Id == idBook);

			}

			return context.Book.Where((b => b.PublishDate >= filters.StartDate && b.PublishDate <= filters.EndDate));
		}
	}
}

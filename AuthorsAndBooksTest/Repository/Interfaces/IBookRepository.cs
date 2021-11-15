using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Entities;
using System.Collections.Generic;

namespace AuthorsAndBooksTest.Repository.Interfaces
{
	public interface IBookRepository
	{
		IEnumerable<Book> Get();
		IEnumerable<Book> GetBooksByFilters(BooksByAuthor filters);
	}
}

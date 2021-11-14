using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository.Interfaces
{
	public interface IBookRepository
	{
		IEnumerable<Book> Get();
		IEnumerable<Book> GetBooksByFilters(BooksByAuthor filters);
	}
}

using AuthorsAndBooksTest.Entities;
using System.Collections.Generic;

namespace AuthorsAndBooksTest.Repository.Interfaces
{
	public interface IAuthorRepository
	{
		IEnumerable<Author> Get();
	}
}

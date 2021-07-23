using AuthorsAndBooks.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.BindingModel
{
	public class BooksByAuthor
	{
		public List<Author> Author { get; set; }
		public List<Book> Book { get; set; }

	}
}

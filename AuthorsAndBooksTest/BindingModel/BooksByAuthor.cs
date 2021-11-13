using AuthorsAndBooks.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.BindingModel
{
	public class BooksByAuthor
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string IdBook { get; set; }

	}
}

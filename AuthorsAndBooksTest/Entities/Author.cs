using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Entities
{
	public class Author
	{
		[Key]
		public int Id { get; set; }
		public int IdBook { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}

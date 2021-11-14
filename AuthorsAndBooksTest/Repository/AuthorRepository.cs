using AuthorsAndBooksTest.Context;
using AuthorsAndBooksTest.Entities;
using AuthorsAndBooksTest.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository
{
	public class AuthorRepository: IAuthorRepository
	{
		private readonly AppDbContext context;
		public AuthorRepository(AppDbContext context)
		{
			this.context = context;
		}
		public IEnumerable<Author> Get()
		{
			return context.Author.ToList();

		}
	}
}

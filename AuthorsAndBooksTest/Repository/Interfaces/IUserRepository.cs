using AuthorsAndBooksTest.BindingModel;
using System;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository.Interfaces
{
	public interface IUserRepository
	{
		/// <summary>
		/// Authentication user
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		Task<Boolean> Authentication(User request);
	}
}

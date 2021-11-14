using AuthorsAndBooksTest.BindingModel;
using AuthorsAndBooksTest.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository
{
	public class UserRepository: IUserRepository
	{
		public async Task<Boolean> Authentication(User request)
		{
			var httpClient = new HttpClient();
			var json = await httpClient.GetStringAsync("https://fakerestapi.azurewebsites.net/api/v1/Users");

			var users = JsonConvert.DeserializeObject<List<User>>(json);
			var userLogin = users.Where(u => u.UserName.Equals(request.UserName) && u.Password.Equals(request.Password)).FirstOrDefault();
			if (userLogin == null)
			{
				return false;

			}

			return true;
		}
	}
}


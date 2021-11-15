using System;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository.Interfaces
{
	public interface ISynchronizationRepository
	{
		Task<Boolean> Synchronization();
	}
}

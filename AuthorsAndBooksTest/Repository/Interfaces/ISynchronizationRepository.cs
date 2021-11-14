using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooksTest.Repository.Interfaces
{
	public interface ISynchronizationRepository
	{
		Task<Boolean> Synchronization();
	}
}

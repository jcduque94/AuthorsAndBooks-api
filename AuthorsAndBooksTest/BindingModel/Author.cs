using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorsAndBooks.BindingModel
{
    public class Author
    {
        public int Id { get; set; }
        public int IdBook { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

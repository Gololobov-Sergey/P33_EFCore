using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Author
    {

        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set;}
        public string? Surname { get; set; }

        //public string? FullName { get;}

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public List<Book> Books { get; set; } = new();
    }
}

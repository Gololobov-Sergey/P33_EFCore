using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public Author Author { get; set; }                 

        //public List<Book> Books { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Models
{
    //[Table("books")]
    //[Index("Pages")]
    public class Book
    {
        //[Column("id_book")]
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [Required]
        public string? Title { get; set; }
        
        //[NotMapped]
        public string Description { get; set; }

        
        public int Pages { get; set; }

        public DateOnly PublishDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);


        public int AuthorInfoKey { get; set; }

        //[ForeignKey("AuthorInfoKey")]
        public Author? Author { get; set; }

        public List<Genre> Genres { get; set; } = [];

        public List<BookGenres> BookGenres { get; set; } = [];

    }
}

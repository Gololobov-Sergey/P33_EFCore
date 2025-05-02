using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Dapper.Models
{
    [Table("Student")]
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {BirthDay.ToShortDateString()}";
        }
    }
}

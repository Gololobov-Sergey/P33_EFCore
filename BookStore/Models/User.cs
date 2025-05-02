using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //[Table("Employees")]
    public class  Employee : User
    {
        public int Salary { get; set; }
    }

    //[Table("Managers")]
    public class Manager : Employee
    {
        public string Departments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Dapper.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new List<Student>();

        public Curator Curator { get; set; }

        public int CuratorId { get; set; }


        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}

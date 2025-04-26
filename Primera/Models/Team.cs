using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }


        public List<Player> Players { get; set; }

        public List<Match> Matches1 { get; set; }

        public List<Match> Matches2 { get; set; }


        public override string ToString()
        {
            return $"{Name} ({City})";
        }

    }
}

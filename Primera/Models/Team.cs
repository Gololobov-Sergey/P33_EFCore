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
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }


        public  int GoalsScored { get; set; }
        public  int GoalsConceded { get; set; }


        public override string ToString()
        {
            return $"{Name} ({City}) - Wins: {Wins}, Losses: {Losses}, Draws: {Draws}";
        }

    }
}

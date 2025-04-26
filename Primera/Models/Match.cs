using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera.Models
{
    public class Match
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public override string ToString()
        {
            return $"{Id.ToString().PadLeft(3)} {Date.ToShortDateString()}  {(Team1.Name + " vs " + Team2.Name).PadRight(40)} -  {Team1Score}:{Team2Score}";
        }
    }
}

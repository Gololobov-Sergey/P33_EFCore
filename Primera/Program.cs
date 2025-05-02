using Microsoft.EntityFrameworkCore;
using Primera.Models;

namespace Primera
{
    internal class Program
    {
        static void AddMatches()
        {
            using (var db = new DBContext())
            {
                db.Matches.RemoveRange(db.Matches);

                DateTime startDate = new DateTime(2025, 4, 1);
                DateTime endDate = new DateTime(2025, 4, 30);

                var teams = db.Teams.ToList();
                for (int i = 0; i < teams.Count; i++)
                {
                    for (int j = i + 1; j < teams.Count; j++)
                    {
                        var randomTest = new Random();

                        TimeSpan timeSpan = endDate - startDate;
                        TimeSpan newSpan = new TimeSpan(0, randomTest.Next(0, (int)timeSpan.TotalMinutes), 0);
                        DateTime newDate = startDate + newSpan;

                        Match match1 = new Match
                        {
                            Team1Id = teams[i].Id,
                            Team2Id = teams[j].Id,
                            Date = DateOnly.FromDateTime(newDate.Date),
                            Team1Score = randomTest.Next(0, 3),
                            Team2Score = randomTest.Next(0, 3)
                        };

                        Match match2 = new Match
                        {
                            Team1Id = teams[j].Id,
                            Team2Id = teams[i].Id,
                            Date = DateOnly.FromDateTime(newDate.Date),
                            Team1Score = randomTest.Next(0, 3),
                            Team2Score = randomTest.Next(0, 3)
                        };
                        db.Matches.AddRange(match1, match2);
                    }

                    db.SaveChanges();
                }
            }
        }

        static void Main(string[] args)
        {

            #region AddTeams

            //using (var db = new DBContext())
            //{
            //    //Team team1 = new Team
            //    //{
            //    //    Name = "FC Barcelona",
            //    //    City = "Barcelona",
            //    //    Wins = 30,
            //    //    Losses = 5,
            //    //    Draws = 3
            //    //};

            //    //Team team2 = new Team
            //    //{
            //    //    Name = "Real Madrid",
            //    //    City = "Madrid",
            //    //    Wins = 28,
            //    //    Losses = 6,
            //    //    Draws = 4
            //    //};
            //    //Team team3 = new Team
            //    //{
            //    //    Name = "Atletico de Madrid",
            //    //    City = "Madrid",
            //    //    Wins = 25,
            //    //    Losses = 8,
            //    //    Draws = 5
            //    //};

            //    //Team team4 = new Team
            //    //{
            //    //    Name = "Valencia CF",
            //    //    City = "Valencia",
            //    //    Wins = 20,
            //    //    Losses = 10,
            //    //    Draws = 5
            //    //};

            //    //Team team5 = new Team
            //    //{
            //    //    Name = "Real Betis",
            //    //    City = "Sevilla",
            //    //    Wins = 18,
            //    //    Losses = 12,
            //    //    Draws = 8
            //    //};

            //    //Team team6 = new Team
            //    //{
            //    //    Name = "Athletic Club",
            //    //    City = "Bilbao",
            //    //    Wins = 15,
            //    //    Losses = 10,
            //    //    Draws = 5
            //    //};

            //    //db.Teams.AddRange(team4, team5, team6);
            //    //db.SaveChanges();


            //    var teams = db.Teams.ToList();
            //    foreach (var team in teams)
            //    {
            //        Console.WriteLine(team);
            //    }
            //}
            #endregion

            //AddMatches();

            //using (var db = new DBContext())
            //{

            //    var matches = db.Matches
            //        .Include(m => m.Team1)
            //        .Include(m => m.Team2)
            //        .Where(m => m.Date == new DateOnly(2025, 4, 7))
            //        .ToList();
            //    foreach (var match in matches)
            //    {
            //        Console.WriteLine(match);
            //    }
            //}



            using (DBContext db = new())
            {
                string city = "Madrid";
                //var teams = db.Teams.FromSqlRaw($"SELECT * FROM GetTeamsFromCity('{city}')").ToList();
                var teams = db.GetTeamsFromCity(city).ToList();
                foreach (var team in teams)
                {
                    Console.WriteLine(team);
                }
            }
        }
    }
}

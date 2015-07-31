using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using _1.EntityFrameworkMapping;

namespace Problem_2.Export_the_Leagues_and_Teams_asJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();

            var leaguesWithTeams = context.Leagues
              .OrderBy(l => l.LeagueName)
              .Select(l => new
              {
                  leagueName = l.LeagueName,
                  teams = l.Teams
                      .OrderBy(t => t.TeamName)
                      .Select(t => t.TeamName)
              })
              .ToList();

            var jsonSerializer = new JavaScriptSerializer();
            var json = jsonSerializer.Serialize(leaguesWithTeams);
            File.WriteAllText("leagues-and-teams.json", json);
            Console.WriteLine("File leagues-and-teams.json exported.");

        }
    }
}

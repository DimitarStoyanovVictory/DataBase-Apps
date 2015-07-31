using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using _1.EntityFrameworkMapping;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace EntityFrameworkMapping
{
    public class Exam
    {
        private static void Main()
        {
            var context = new FootballEntities1();

            #region Problem 1.	Entity Framework Mappings (Database First)

            //context.Teams.Select(t => t.TeamName).ToList().ForEach(t => Console.WriteLine(t));

            #endregion

            #region Problem 2.	Export the Leagues and Teams as JSON

            //var json = JsonConvert.SerializeObject(context.Leagues.Select(l => new
            //{
            //    leagueName = l.LeagueName,
            //    teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
            //}).ToList().OrderBy(l => l.leagueName));

            //Console.WriteLine(json);
            //File.WriteAllText("leagues-and-teams.json", json);

            #endregion

            #region Problem 3.	Export International Matches as XML

            //var internationalMatches = context.InternationalMatches
            //    .Select(i => new
            //    {
            //        homeScore = i.HomeGoals,
            //        awayScore = i.AwayGoals,
            //        homeCodeCountry = i.HomeCountryCode,
            //        awayCodeCountry = i.AwayCountryCode,
            //        homeCountry = i.CountryHome,
            //        awayCountry = i.CountryAway,
            //        date = i.MatchDate,
            //        leagueName = i.League.LeagueName
            //    }).ToList().OrderBy(i => i.date)
            //    .ThenBy(i => i.homeCountry.CountryName)
            //    .ThenBy(i => i.awayCountry.CountryName);

            //var matches = new XElement("matches");

            //foreach (var match in internationalMatches)
            //{
            //    XElement xmlMatch =
            //        new XElement("match",
            //            new XElement("home-country",
            //                new XAttribute("code", match.homeCodeCountry),
            //                match.homeCountry.CountryName),
            //            new XElement("away-country",
            //                new XAttribute("code", match.awayCodeCountry),
            //                match.awayCountry.CountryName)
            //        );

            //    if (match.leagueName != null)
            //    {
            //        xmlMatch.Add(
            //            new XElement("league", match.leagueName)
            //            );
            //    }

            //    if (match.date != null)
            //    {
            //        DateTime dateTime;
            //        DateTime.TryParse(match.date.ToString(), out dateTime);

            //        if (dateTime.TimeOfDay.TotalSeconds == 0.0)
            //        {
            //            xmlMatch.Add(new XAttribute("date", dateTime.ToString("dd-MMM-yyyy")));
            //        }
            //        else
            //        {
            //            xmlMatch.Add(new XAttribute("date-time", dateTime.ToString("dd-MMM-yyyy hh:mm")));
            //        }
            //    }

            //    if (match.homeScore != null && match.awayScore != null)
            //    {
            //        xmlMatch.LastNode.AddAfterSelf(
            //        new XElement("score", match.homeScore + "-" + match.awayScore)
            //        );
            //    }

            //    matches.Add(xmlMatch);
            //    matches.Save("../../international-matches.xml ");
            //} 

            //Console.WriteLine(matches);

            #endregion

            #region Problem 4.	Import Leagues and Teams from XML1

            var doc = new XmlDocument();
            doc.Load("../../leagues-and-teams.xml");

            int id = 0;
            var root = doc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                Console.WriteLine("Processing league #{0} ...", ++id);

                League league = new League();
                XmlNode xmlLeague = node.SelectSingleNode("league-name");
                if (xmlLeague != null)
                {
                    string leagueName = node.SelectSingleNode("league-name").InnerText;
                    league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                                        
                    if (league != null)
                    {
                        Console.WriteLine("Existing league: {0}", leagueName);
                    }
                    else
                    {
                        league = new League()
                        {
                            LeagueName = leagueName
                        };
                        context.Leagues.Add(league);

                        Console.WriteLine("Created league: {0}", leagueName);
                    }

                    context.SaveChanges();
                }

                XmlNode xmlTeams = node.SelectSingleNode("teams");

                if (xmlTeams != null)
                {
                    foreach (XmlNode xmlTeam in xmlTeams.ChildNodes)
                    {
                        string teamName = xmlTeam.Attributes["name"].Value;
                        Country country = new Country();
                        Team team = new Team();
                        team.TeamName = teamName;

                        if (xmlTeam.Attributes["country"] != null)
                        {
                            string countryName = xmlTeam.Attributes["country"].Value;
                            team.Country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                        }
                        else
                        {
                            team.Country = new Country()
                            {
                                CountryName = ""
                            };
                        }

                        if (context.Teams.Any(t => t.TeamName == teamName))
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamName,
                                country.CountryName ?? "no country");
                        }
                        else
                        {
                            context.Teams.Add(team);
                            Console.WriteLine("Created team: {0} ({1})", team.TeamName,
                                team.Country.CountryName ?? "no country");
                        }

                        if (league.LeagueName != null)
                        {
                            if (league.Teams.Contains(team))
                            {
                                Console.WriteLine("Existing team in league: {0} belongs to {1}", teamName,
                                    league.LeagueName);
                            }
                            else
                            {
                                league.Teams.Add(team);
                                Console.WriteLine("Added team to league: {0} to league {1}", teamName, league.LeagueName);
                                context.SaveChanges();
                            }
                        }

                        context.SaveChanges();
                    }
                }

                Console.WriteLine();
            }
            #endregion

            #region Problem 4.	Import Leagues and Teams from XML2

            //var doc = new XmlDocument();
            //doc.Load("../../leagues-and-teams.xml");

            //var root = doc.DocumentElement;
            //int id = 0;

            //foreach (XmlNode xmlLeague in root.ChildNodes)
            //{
            //    Console.WriteLine("Processing league #{0}", ++id);
            //    XmlNode leagueNameNode = xmlLeague.SelectSingleNode("league-name");
            //    League league = null;
            //    if (leagueNameNode != null)
            //    {
            //        string leagueName = leagueNameNode.InnerText;

            //        league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
            //        if (league != null)
            //        {
            //            Console.WriteLine("Existing league: {0}", leagueName);
            //        }
            //        else
            //        {
            //            context.Leagues.Add(new League()
            //            {
            //                LeagueName = leagueName
            //            });
            //            Console.WriteLine("Creating league: {0}", leagueName);
            //        }
            //    }

            //    XmlNode teamsNode = xmlLeague.SelectSingleNode("teams");

            //    if (teamsNode != null)
            //    {
            //        foreach (XmlNode Xmlteam in teamsNode)
            //        {
            //            string teamName = Xmlteam.Attributes["name"].Value;
            //            string countryName = "";

            //            if (Xmlteam.Attributes["country"] != null)
            //            {
            //                countryName = Xmlteam.Attributes["country"].Value;
            //            }

            //            Team team = context.Teams.FirstOrDefault(t => t.TeamName == teamName);  
            //            if (context.Teams.Any(t => t.TeamName == teamName && t.Country.CountryName == countryName))
            //            {
            //                Console.WriteLine("Exsiting team {0} ({1})", teamName, countryName ?? "(no country)");
            //            }
            //            else
            //            {
            //                Country country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);

            //                if (countryName != null)
            //                {
            //                    country = new Country()
            //                    {
            //                        CountryName = countryName
            //                    };
            //                }

            //                context.Teams.Add(new Team()
            //                {
            //                     TeamName = teamName,
            //                     Country = country
            //                });

            //                Console.WriteLine("Created team: {0} ({1})", teamName, countryName ?? "(no country)");
            //            }
            //            var x = league.Teams.Contains(team);
            //            if (league != null)
            //            {

            //            }
            //        }
            //    }

            //    context.SaveChanges();
            //}


            #endregion
        }
    }
}


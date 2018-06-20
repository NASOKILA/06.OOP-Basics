using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {


                try
                {
                    string[] tokens = input
                        .Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    if (tokens.Length < 2)
                    {
                        Console.WriteLine("A name should not be empty.");
                        continue;
                    }
                    
                    string command = tokens[0];
                    string teamName = tokens[1];

                    if (command == "Team")
                    {
                        Team team = new Team(teamName);

                        if (!teams.Contains(team))
                            teams.Add(team);
                    }
                    else if (command == "Add")
                    {

                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Team team = teams
                            .First(t => t.Name == teamName);

                        string playerName = tokens[2];

                        int enduranceStatValue = int.Parse(tokens[3]);
                        Stat endurance = new Stat("Endurance", enduranceStatValue);

                        int sprintStatValue = int.Parse(tokens[4]);
                        Stat sprint = new Stat("Sprint", sprintStatValue);

                        int dribbleStatValue = int.Parse(tokens[5]);
                        Stat dribble = new Stat("Dribble", dribbleStatValue);

                        int passingStatValue = int.Parse(tokens[6]);
                        Stat passing = new Stat("Passing", passingStatValue);

                        int shootingStatValue = int.Parse(tokens[7]);
                        Stat shooting = new Stat("Shooting", shootingStatValue);

                        List<Stat> playerStats = new List<Stat>();
                        playerStats.Add(endurance);
                        playerStats.Add(sprint);
                        playerStats.Add(dribble);
                        playerStats.Add(passing);
                        playerStats.Add(shooting);

                        Player player = new Player(playerName, playerStats);

                        if (!team.Players.Contains(player))
                            team.AddPlayer(player);

                    }
                    else if (command == "Remove")
                    {
                        string playerName = tokens[2];

                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Team team = teams.First(t => t.Name == teamName);

                        if (!team.Players.Any(p => p.Name == playerName))
                        {
                            Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                            continue;
                        }

                        Player player = team.Players.First(p => p.Name == playerName);
                        team.RemovePlayer(player);

                    }
                    else if (command == "Rating")
                    {

                        if (!teams.Any(t => t.Name == teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }
                        Team team = teams.First(t => t.Name == teamName);

                        int rating = 0;

                        if (team.Players.Count > 0)
                            rating = team.GetRating();


                        Console.WriteLine($"{teamName} - {rating}");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

        }
    }
}

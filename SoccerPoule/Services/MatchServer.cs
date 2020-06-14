using System;
using System.Collections.Generic;
using SoccerPoule.Models;

namespace SoccerPoule.Services
{
    public class MatchServer : IMatchServer
    {
        public List<Match> MatchResults { get; set; } = new List<Match>();

        public MatchServer()
        {
        }

        public Match PlayMatch(Team team1, Team team2)
        {
            var team1Goals = 0;
            var team2Goals = 0;
            int scoringProbTeam1VsTeam2 = team1.Attack + team1.Motivation - team2.Defense;
            int scoringProbTeam2VsTeam1 = team2.Attack + team2.Motivation - team1.Defense;
            var random = new Random();

            for (var i = 0; i < 10; i++)
            {
                int x = random.Next(0, 100);
                if (x < scoringProbTeam1VsTeam2)
                {
                    team1Goals++;
                }

                int y = random.Next(0, 100);
                if (y < scoringProbTeam2VsTeam1)
                {
                    team2Goals++;
                }
            }

            var matchResult = new Match
            {
                Team1 = team1,
                Team2 = team2,
                Team1Goals = team1Goals,
                Team2Goals = team2Goals
            };

            MatchResults.Add(matchResult);
            return matchResult;
        }
    }
}

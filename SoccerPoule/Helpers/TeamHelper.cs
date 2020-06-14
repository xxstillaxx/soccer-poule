using System.Collections.Generic;
using SoccerPoule.Models;

namespace SoccerPoule.Helpers
{
    public static class TeamHelper
    {
        public static List<Team> GenerateTeams()
        {
            return new List<Team>
            {
                new Team { Name = "Team A", Attack = 80, Defense = 80 },
                new Team { Name = "Team B", Attack = 65, Defense = 80 },
                new Team { Name = "Team C", Attack = 20, Defense = 20 },
                new Team { Name = "Team D", Attack = 99, Defense = 30 }
            };
        }

        public static int GoalDifference(this Team team)
        {
            return team.GoalsScored - team.GoalsAgainst;
        }

        public static void UpdateWon(this Team team)
        {
            team.Won++;
            team.Motivation += 5;
            team.Points += 3;
        }

        public static void UpdateLost(this Team team)
        {
            team.Lost++;
            team.Motivation -= 5;
        }

        public static void UpdateDraw(this Team team)
        {
            team.Draw++;
            team.Points++;
        }

        public static void UpdateGoals(this Team team, int goalsScored, int goalsAgainst)
        {
            team.GoalsScored += goalsScored;
            team.GoalsAgainst += goalsAgainst;
        }
    }
}

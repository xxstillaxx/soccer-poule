using SoccerPoule.Models;

namespace SoccerPoule.Services
{
    public interface IMatchServer
    {
        /// <summary>
        /// Starts op a match between 2 teams
        /// </summary>
        /// <returns>Match results</returns>
        Match PlayMatch(Team team1, Team team2);
    }
}
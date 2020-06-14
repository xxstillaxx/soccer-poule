namespace SoccerPoule.Models
{
    public class Match
    {
        public Team Team1 { get; set; }

        public Team Team2 { get; set; }

        public int Team1Goals { get; set; }

        public int Team2Goals { get; set; }
    }
}

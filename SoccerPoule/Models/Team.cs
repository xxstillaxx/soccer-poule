namespace SoccerPoule.Models
{
    public class Team
    {
        public string Name { get; set; }

        public int Defense { get; set; }

        public int Attack { get; set; }

        public int Motivation { get; set; }

        public int Won { get; set; }

        public int Lost { get; set; }

        public int Draw { get; set; }

        public int Points { get; set; }

        public int GoalsAgainst { get; set; }

        public int GoalsScored { get; set; }
    }
}

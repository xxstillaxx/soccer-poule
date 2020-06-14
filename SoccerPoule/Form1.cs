using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SoccerPoule.Helpers;
using SoccerPoule.Models;
using SoccerPoule.Services;

namespace SoccerPoule
{
    public partial class Form1 : Form
    {
        private readonly IMatchServer _matchServer;
        private List<Team> _teams;

        public Form1(IMatchServer matchServer)
        {
            _matchServer = matchServer;

            _teams = TeamHelper.GenerateTeams();
            InitializeComponent();
            UpdateDataGrid();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            // play all matches
            PlayMatch(_teams[0], _teams[1]);
            PlayMatch(_teams[0], _teams[2]);
            PlayMatch(_teams[0], _teams[3]);
            PlayMatch(_teams[1], _teams[2]);
            PlayMatch(_teams[1], _teams[3]);
            PlayMatch(_teams[2], _teams[3]);
        }

        private void PlayMatch(Team team1, Team team2)
        {
            Match matchResult = _matchServer.PlayMatch(team1, team2);
            UpdateWinLoss(team1, team2, matchResult.Team1Goals, matchResult.Team2Goals);
            textBox1.AppendText($"{team1.Name} vs {team2.Name} = ({matchResult.Team1Goals} - {matchResult.Team2Goals})");
            textBox1.AppendText(Environment.NewLine);
            UpdateDataGrid();
        }

        private void UpdateWinLoss(Team team1, Team team2, int team1Goals, int team2Goals)
        {
            team1.UpdateGoals(team1Goals, team2Goals);
            team2.UpdateGoals(team2Goals, team1Goals);

            //team1 wins
            if (team1Goals > team2Goals)
            {
                team1.UpdateWon();
                team2.UpdateLost();
            }
            //team2 wins
            else if (team2Goals > team1Goals)
            {
                team2.UpdateWon();
                team1.UpdateLost();
            }
            //draw
            else if (team1Goals == team2Goals)
            {
                team1.UpdateDraw();
                team2.UpdateDraw();
            }
        }

        private void UpdateDataGrid()
        {
            var data = new List<object>();
            IEnumerable<Team> sortedTeams = SortTeams(_teams);
            foreach (Team team in sortedTeams)
            {
                data.Add(new
                {
                    team.Name,
                    team.Points,
                    team.Won,
                    team.Lost,
                    team.Draw,
                    team.GoalsScored,
                    team.GoalsAgainst,
                    GoalDifference = team.GoalDifference()
                });
            }

            dataGridView.DataSource = data;
        }

        private IEnumerable<Team> SortTeams(IEnumerable<Team> teams)
        {
            return teams
                .OrderByDescending(t => t.Points)
                .ThenByDescending(t => t.GoalDifference())
                .ThenByDescending(t => t.GoalsScored)
                .ThenBy(t => t.GoalsAgainst)
                .ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _teams = TeamHelper.GenerateTeams();
            UpdateDataGrid();
            textBox1.Text = string.Empty;
        }
    }
}

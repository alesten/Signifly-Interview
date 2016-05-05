using System.Collections.Generic;
using Signifly_Interview.Models;

namespace Signifly_Interview.ViewModels
{
    public class TeamsViewModel
    {
        public List<Team> Teams { get; set; }
        public AddTeamViewModel AddTeamViewModel { get; set; }
    }

    public class AddTeamViewModel
    {
        public string Name { get; set; }

        public Team ToTeam()
        {
            return new Team
            {
                Name = Name
            };
        }
    }

    public class ShowTeamViewModel
    {
        public Team Team { get; set; }
    }
}
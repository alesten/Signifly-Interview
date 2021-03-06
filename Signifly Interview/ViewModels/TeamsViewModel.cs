﻿using System.Collections.Generic;
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
        public Team Team { get; set; }
        public List<AddTeamSkill> Skills { get; set; }
    }

    public class AddTeamSkill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amt { get; set; }
    }

    public class ShowTeamViewModel
    {
        public Team Team { get; set; }
    }
}
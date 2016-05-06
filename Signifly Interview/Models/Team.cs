using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signifly_Interview.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
        public List<SkillAmt> Skills { get; set; }
    }

    public class SkillAmt
    {
        public string Name { get; set; }
        public int Amt { get; set; }
    }
}

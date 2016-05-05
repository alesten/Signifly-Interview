using System.Collections.Generic;

namespace Signifly_Interview.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public List<TeamMemberSkill> Skills { get; set; }
    }
}
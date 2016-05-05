using System.Data.SqlClient;
using Signifly_Interview.Database.Storage;
using Signifly_Interview.Models;

namespace Signifly_Interview.Database.Mapper
{
    public class TeamMemberMapper
    {
        public static TeamMember Map(SqlDataReader reader)
        {
            var teamMember = new TeamMember();

            teamMember.Id = (int) reader["TeamMember_Id"];
            teamMember.Skills = TeamMemberStorage.Instance.GetSkills(teamMember.Id);
            teamMember.Name = reader["TeamMemberName"].ToString();
            teamMember.Email = reader["TeamMemberEmail"].ToString();
            teamMember.Mobile = reader["TeamMemberMobile"].ToString();
            teamMember.Description = reader["TeamMemberDescription"].ToString();
            teamMember.Position = reader["TeamMemberPosition"].ToString();

            return teamMember;
        }

        public static TeamMemberSkill MapSkill(SqlDataReader reader)
        {
            var skill = new TeamMemberSkill();

            skill.Id = (int)reader["TeamMemberSkill_Id"];
            skill.Name = reader["TeamMemberSkillName"].ToString();

            return skill;
        }
    }
}
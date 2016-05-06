using System.Data.SqlClient;
using Signifly_Interview.Models;

namespace Signifly_Interview.Database.Mapper
{
    public class TeamMapper
    {
        public static Team Map(SqlDataReader reader)
        {
            var team = new Team();

            team.Id = (int)reader["Team_Id"];
            team.Name = reader["TeamName"].ToString();
            team.Description = reader["TeamDescription"].ToString();

            return team;
        }

        public static SkillAmt MapSkillOverview(SqlDataReader reader)
        {
            var skill = new SkillAmt();

            skill.Name = reader["TeamMemberSkillName"].ToString();
            skill.Amt = (int) reader["Amt"];

            return skill;
        }
    }
}
using System.Data.SqlClient;
using Signifly_Interview.Models;

namespace Signifly_Interview.Database.Mapper
{
    public class TeamMemberMapper
    {
        public static TeamMember Map(SqlDataReader reader)
        {
            var teamMember = new TeamMember();

            teamMember.Id = (int) reader["TeamMember_Id"];
            teamMember.Name = reader["TeamMemberName"].ToString();
            teamMember.Email = reader["TeamMemberEmail"].ToString();
            teamMember.Mobile = reader["TeamMemberMobile"].ToString();
            teamMember.Description = reader["TeamMemberDescription"].ToString();

            return teamMember;
        }
    }
}
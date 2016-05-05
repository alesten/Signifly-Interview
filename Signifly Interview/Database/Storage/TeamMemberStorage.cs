using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Signifly_Interview.Database.Mapper;
using Signifly_Interview.Models;

namespace Signifly_Interview.Database.Storage
{
    public class TeamMemberStorage : BaseStorage
    {
        #region Singleton

        private static TeamMemberStorage _instace;

        public static TeamMemberStorage Instance => _instace ?? (_instace = new TeamMemberStorage());

        private TeamMemberStorage() { }

        #endregion

        #region Get

        public List<TeamMember> GetTeamMembers()
        {
            var teamMembers = new List<TeamMember>();

            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spGetTeamMembers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teamMembers.Add(TeamMemberMapper.Map(reader));
                        }
                    }
                }
            }

            return teamMembers;
        }

        public List<TeamMemberSkill> GetSkills(int memberId)
        {
            var skills = new List<TeamMemberSkill>();

            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spGetTeamMemberSkills", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("TeamMember_Id", SqlDbType.Int).Value = memberId;

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            skills.Add(TeamMemberMapper.MapSkill(reader));
                        }
                    }
                }
            }

            return skills;
        }

        #endregion
    }
}
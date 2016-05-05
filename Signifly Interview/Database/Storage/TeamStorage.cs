using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Signifly_Interview.Database.Mapper;
using Signifly_Interview.Models;

namespace Signifly_Interview.Database.Storage
{
    public class TeamStorage : BaseStorage
    {
        #region Singleton

        private static TeamStorage _instance;

        private TeamStorage() { }

        public static TeamStorage Instance => _instance ?? (_instance = new TeamStorage());

        #endregion

        #region Get

        public List<Team> GetTeams()
        {
            var teams = new List<Team>();

            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spGetTeams", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            teams.Add(TeamMapper.Map(reader));
                        }
                    }
                }
            }

            return teams;
        }

        public Team GetTeam(int id)
        {
            Team team = null;

            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spGetTeamWithMembers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("Team_Id", SqlDbType.Int).Value = id;

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (team == null)
                            {
                                team = TeamMapper.Map(reader);
                                team.TeamMembers = new List<TeamMember>();
                            }

                            team.TeamMembers.Add(TeamMemberMapper.Map(reader));
                        }
                        return team;
                    }

                }
            }
        }

        #endregion

        #region Add

        public void AddTeam(Team team)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spAddTeam", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("TeamName", SqlDbType.NVarChar).Value = team.Name;

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}

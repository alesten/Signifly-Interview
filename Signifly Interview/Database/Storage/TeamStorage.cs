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
                            var team = TeamMapper.Map(reader);

                            team.Skills = GetSkillOverviewForTeam(team.Id);

                            teams.Add(team);
                        }
                    }
                }
            }

            return teams;
        }

        private List<SkillAmt> GetSkillOverviewForTeam(int id)
        {
            var skills = new List<SkillAmt>();

            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spGetSkillsForTeam", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("Team_Id", SqlDbType.Int).Value = id;

                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            skills.Add(TeamMapper.MapSkillOverview(reader));
                        }
                    }
                }
            }

            return skills;
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
                            try
                            {
                                team.TeamMembers.Add(TeamMemberMapper.Map(reader));
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                        return team;
                    }
                }
            }
        }

        public List<TeamMemberSkill> GetAvailableSkills()
        {
            var skills = new List<TeamMemberSkill>();

            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spGetSkills", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

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

        #region Add

        public int AddTeam(Team team)
        {
            using (var con = new SqlConnection(ConnectionString))
            {
                using (var cmd = new SqlCommand("spAddTeam", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("TeamName", SqlDbType.NVarChar).Value = team.Name;
                    cmd.Parameters.Add("TeamDescription", SqlDbType.NVarChar).Value = team.Description.Replace("\r\n", "<br>");

                    con.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (int) reader["Team_Id"];
                        }
                    }
                }
            }
            return -1;
        }

        #endregion
    }
}

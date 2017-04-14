using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LeagueTeam.ViewModel;
using System.Data.SqlClient;
using LeagueTeam.Models;

namespace LeagueTeam.Services
{
    public class LeagueService
    {
        private string _ConnectionString;

        public LeagueService(string connectionString)
        {
            this._ConnectionString = connectionString;
        }

        public IEnumerable<Team> GetAllTeams()
        {
            var rv = new List<Team>();
            using (var connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Teams";
                var cmd = new SqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rv.Add(new Team(reader));
                }

                connection.Close();
            }
            return rv;
        }
        public IndexViewModel GetCountOfPlayersAndTeams()
        {
            var rv = new IndexViewModel();
            using (var connection = new SqlConnection(_ConnectionString))
            {
                connection.Open();
                rv.PlayerCount = this.GetCountOfPlayers(connection);
                rv.TeamCount = this.GetCountOfTeams(connection);
                connection.Close();
            }
            return rv;
        }

        private int GetCountOfPlayers(SqlConnection connection)
        {
            var query = "SELECT COUNT(Id) FROM Players";
            var cmd = new SqlCommand(query, connection);
            var count = cmd.ExecuteScalar();
            return (int)count;
        }

        private int GetCountOfTeams(SqlConnection connection)
        {
            var query = "SELECT COUNT(Id) FROM Teams";
            var cmd = new SqlCommand(query, connection);
            var count = cmd.ExecuteScalar();
            return (int)count;
        }

    }
}
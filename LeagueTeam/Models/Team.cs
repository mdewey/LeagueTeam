using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LeagueTeam.Models
{
    public class Team
    {
        public Team()
        {

        }
        public Team(SqlDataReader reader)
        {
            this.Id = (int)reader["Id"];
            this.Mascot = reader["Mascot"]?.ToString();
            this.Color = reader["Color"]?.ToString();
            this.Wins = reader["Wins"] as int?;
            this.Loses = reader["Loss"] as int?;
        }

        public int Id { get; set; }
        public string Mascot { get; set; }
        public string Color { get; set; }
        public int? Wins { get; set; }
        public int? Loses { get; set; }
    }
}
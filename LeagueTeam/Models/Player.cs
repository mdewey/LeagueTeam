using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueTeam.Models
{
    public class Player
    {
        public Player() { }
        public Player(FormCollection collection)
        {
            this.FullName = collection["FullName"];
            this.Number = int.Parse(collection["Number"]);
            this.SkillLevel = int.Parse(collection["SkillLevel"]);
            this.Position = collection["Position"];
            this.TeamId = int.Parse(collection["TeamId"]);
        }

        public Player(SqlDataReader reader, bool hasTeamData = true)
        {
            this.Id = (int)reader["Id"];
            this.FullName = reader["FullName"].ToString();
            this.Position = reader["PreferedPosition"].ToString();
            this.Number = reader["PreferedJerseyNumber"] as int?;
            this.SkillLevel = reader["SkillLevel"] as int?;
            this.TeamId = reader["TeamId"] as int?;
            if (hasTeamData)
            {
                this.Team = new Team
                {
                    Color = reader["Color"].ToString(),
                    Mascot = reader["Mascot"].ToString(),
                    Id = (int)reader["TeamId"],
                    Loses = reader["Loss"] as int?,
                    Wins = reader["Wins"] as int?
                };
            }
            else
            {
                this.Team = new Team() { Id = (int)reader["TeamId"] };
            }
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int? Number { get; set; }
        public int? SkillLevel { get; set; }
        public string Position { get; set; }


        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
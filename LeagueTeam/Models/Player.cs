using System;
using System.Collections.Generic;
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

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Number { get; set; }
        public int SkillLevel { get; set; }
        public string Position { get; set; }


        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
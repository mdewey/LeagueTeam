using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueTeam.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Mascot { get; set; }
        public string Color { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }

    }
}
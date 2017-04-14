using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueTeam.ViewModel
{
    public class PlayerIndexViewModel
    {
        public int PlayerId { get; set; }
        public int? TeamId { get; set; }
        public string FullName { get; set; }
        public int? SkillLevel { get; set; }
        public string Mascot { get; set; }
    }
}
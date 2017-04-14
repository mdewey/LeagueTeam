using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueTeam.Services;
namespace LeagueTeam.Controllers
{
    public class HomeController : Controller
    {
        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=LegaueDatabase;Trusted_Connection=True;";
        LeagueService leagueService = new LeagueService(ConnectionString);


        public ActionResult Index()
        {

            var teams = new List<LeagueTeam.Models.Team>();
            for (int i = 0; i < 10; i++)
            {
                teams.Add(new LeagueTeam.Models.Team
                {
                    Id = i,
                    Mascot = "team " + i
                });
            }
            ViewBag.Teams = teams.Select(s =>
                new SelectListItem() { Value = s.Id.ToString(), Text = s.Mascot });
            var vm = leagueService.GetCountOfPlayersAndTeams();
            return View(vm);



        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var something = collection["TeamName"];
            return View();
        }
    }
}
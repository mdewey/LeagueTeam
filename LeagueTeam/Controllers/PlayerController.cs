using LeagueTeam.Models;
using LeagueTeam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueTeam.Controllers
{
    public class PlayerController : Controller
    {

        const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=LegaueDatabase;Trusted_Connection=True;";
        LeagueService leagueService = new LeagueService(ConnectionString);

        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            // Populate the viewbag with a list of teams
            var teams = leagueService.GetAllTeams();

            ViewBag.Teams = teams.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Mascot });


            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            var player = new Player(collection);
            return View();
        }

    }
}
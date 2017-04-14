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
            var vm = leagueService.GetCountOfPlayersAndTeams();
            return View(vm);
        }
    }
}
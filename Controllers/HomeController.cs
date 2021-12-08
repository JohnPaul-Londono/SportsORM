using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            // all leagues where sport is any type of hockey
            ViewBag.AllWomenLeague = _context.Leagues.Where(w => w.Name.Contains("Women")).ToList();
            // all leagues where sport is any type of hockey
            ViewBag.AnyHockey = _context.Leagues.Where(h => h.Name.Contains("Hockey")).ToList();
            // all leagues where sport is something OTHER THAN football
            ViewBag.NoFootball = _context.Leagues.Where(Nofoot => !Nofoot.Name.Contains("Football")).ToList();
            // ...all leagues that call themselves "conferences"
            ViewBag.SelfConference = _context.Leagues.Where(sc => sc.Name.Contains("Conference")).ToList();
            // ...all leagues in the Atlantic region
            ViewBag.AtlanLoc = _context.Leagues.Where(at => at.Name.Contains("Atlantic")).ToList();
            // ...all teams based in Dallas
            ViewBag.Dallas = _context.Teams.Where(dal => dal.Location.Contains("Dallas")).ToList();
            // ...all teams named the Raptors
            ViewBag.Raptors = _context.Teams.Where(rap => rap.TeamName.Contains("Raptors")).ToList();
            // ...all teams whose location includes "City"
            ViewBag.City = _context.Teams.Where(city => city.Location.Contains("City")).ToList();
            // ...all teams whose names begin with "T"
            ViewBag.teamT = _context.Teams.Where(t => t.TeamName.Contains("T")).ToList();
            // ...all teams, ordered alphabetically by location
            ViewBag.Alpha = _context.Teams.OrderBy(alp => alp.Location).ToList();
            // ...all teams, ordered by team name in reverse alphabetical order
            ViewBag.reverseCity = _context.Teams.OrderByDescending(alp => alp.TeamName).ToList();
            // ...every player with last name "Cooper"
            ViewBag.Cooper = _context.Players.Where(last => last.LastName.Contains("Cooper")).ToList();
            // ...every player with first name "Joshua"
            ViewBag.Josh = _context.Players.Where(first => first.FirstName.Contains("Joshua")).ToList();
            // ...every player with last name "Cooper" EXCEPT those with "Joshua" as the first name
            ViewBag.NoJosh = _context.Players.Where(nj => nj.LastName.Contains("Cooper") && !nj.FirstName.Contains("Joshua")).ToList();
            // ...all players with first name "Alexander" OR first name "Wyatt"
            ViewBag.AlexOrWyatt = _context.Players.Where(aw => aw.FirstName.Contains("Alexander") || aw.FirstName.Contains("Wyatt")).ToList();
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}
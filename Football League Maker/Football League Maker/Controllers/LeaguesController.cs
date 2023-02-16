using Football_League_Maker.DAL;
using Football_League_Maker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Football_League_Maker.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly AppDbContext _db;
        public LeaguesController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            List<League> leagues = await _db.Leagues.Include(x => x.LeagueTeams).ThenInclude(x => x.Team).Where(x => x.IsDeactive == false).ToListAsync();
            return View(leagues);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Teams = await _db.Teams.ToListAsync();
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Create(League league, int[] teamIds)
        {
            ViewBag.Teams = await _db.Teams.ToListAsync();
            league.Name = league.Name?.Trim();
            bool isExists = await _db.Leagues.Where(x => x.IsDeactive == false).AnyAsync(x => x.Name == league.Name);
            if (isExists)
            {
                ModelState.AddModelError("Name", "There is already league under this name.Please change the name");
                return View();
            }

           

            List<LeagueTeam> leagueTeams = new List<LeagueTeam>();

            foreach (int teamId in teamIds)
            {
                LeagueTeam leagueTeam = new LeagueTeam
                {
                    TeamId = teamId
                };

                leagueTeams.Add(leagueTeam);
            }

            league.LeagueTeams = leagueTeams;


            league.NumberOfTeams = leagueTeams.Count();
            await _db.Leagues.AddAsync(league);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }

            League? league = await _db.Leagues.FirstOrDefaultAsync(x => x.Id == id);

            if (league == null)
            {
                return BadRequest();
            }

            league.IsDeactive = true;

            await _db.SaveChangesAsync();



            return RedirectToAction("Index");
        }



        public async Task<IActionResult> Detail(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }

            League? league = await _db.Leagues.FirstOrDefaultAsync(x => x.Id == id);

            if (league == null)
            {
                return BadRequest();
            }



            return View(league);
        }





        public IActionResult Error()
        {
            return View();
        }
    }
}
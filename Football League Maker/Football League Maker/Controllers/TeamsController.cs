using Football_League_Maker.DAL;
using Football_League_Maker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Football_League_Maker.Controllers
{
    public class TeamsController : Controller
    {

        private readonly AppDbContext _db;
        public TeamsController(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<Team> teams = await _db.Teams.Where(x=>x.IsDeactive==false).ToListAsync();
            return View(teams);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Team team)
        {

            team.Name = team.Name?.Trim();
            bool isExists = await _db.Teams.Where(x => x.IsDeactive == false).AnyAsync(x => x.Name == team.Name);
            if (isExists)
            {
                ModelState.AddModelError("Name", "There is already team under this name.Please change the name");
                return View();
            }

            await _db.Teams.AddAsync(team);
            await _db.SaveChangesAsync();


            return RedirectToAction("Index");
        }

    }
}

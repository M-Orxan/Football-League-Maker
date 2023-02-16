using Football_League_Maker.Models;
using Microsoft.EntityFrameworkCore;

namespace Football_League_Maker.DAL
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<League> Leagues {get; set; }
        public DbSet<LeagueTeam> LeagueTeams { get; set; }
    }
}

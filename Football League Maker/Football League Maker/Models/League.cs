using System.ComponentModel.DataAnnotations;

namespace Football_League_Maker.Models
{
    public class League
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int NumberOfTeams { get; set; }

        public bool IsDeactive { get; set; }

        public bool IsCompleted { get; set; }

        public List<Team>? Teams { get; set; }

        public List<LeagueTeam>? LeagueTeams { get; set; }

    }
}

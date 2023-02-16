using System.ComponentModel.DataAnnotations;

namespace Football_League_Maker.Models
{
    public class Team
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool IsDeactive { get; set; }
        public List<LeagueTeam>? LeagueTeams { get; set; }


    }
}

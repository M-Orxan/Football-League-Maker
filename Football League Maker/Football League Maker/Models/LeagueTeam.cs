namespace Football_League_Maker.Models
{
    public class LeagueTeam
    {
        public int Id { get; set; }

        public League League { get; set; }
        public int LeagueId { get; set; }

        public Team Team { get; set; }
        public int TeamId { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class FootballTeam
{
    public int FootballTeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public int? FoundedYear { get; set; }

    public string? Stadium { get; set; }

    public string? City { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

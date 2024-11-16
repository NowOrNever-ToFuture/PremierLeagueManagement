using System;
using System.Collections.Generic;

namespace DAL.Entities;

public partial class Player
{
    public int PlayerId { get; set; }

    public int? FootballTeamId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Position { get; set; }

    public int? JerseyNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Nationality { get; set; }

    public virtual FootballTeam? FootballTeam { get; set; }
}

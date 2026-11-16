using System;
using System.Collections.Generic;

namespace PetsAPI.Models;

public partial class Gazdum
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public virtual ICollection<Kutya>? Kutyas { get; set; } = new List<Kutya>();
}

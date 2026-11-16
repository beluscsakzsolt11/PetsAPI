using System;
using System.Collections.Generic;

namespace PetsAPI.Models;

public partial class Fajtum
{
    public int Id { get; set; }

    public string Megnevezes { get; set; } = null!;

    public string Szarmazas { get; set; } = null!;

    public string Kategoria { get; set; } = null!;

    public string Meret { get; set; } = null!;

    public bool Hipoallergen { get; set; }

    public int EletAlso { get; set; }

    public int EletFelso { get; set; }

    public virtual ICollection<Kutya>? Kutyas { get; set; } = new List<Kutya>();
}

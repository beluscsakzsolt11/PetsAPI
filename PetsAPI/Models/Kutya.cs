using System;
using System.Collections.Generic;

namespace PetsAPI.Models;

public partial class Kutya
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int FajtaId { get; set; }

    public int GazdaId { get; set; }

    public int Eletkor { get; set; }

    public DateOnly Rogzitve { get; set; }

    public virtual Fajtum? Fajta { get; set; } = null!;

    public virtual Gazdum? Gazda { get; set; } = null!;
}

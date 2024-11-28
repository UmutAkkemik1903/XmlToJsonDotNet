using System;
using System.Collections.Generic;

namespace tetacode.Models;

public partial class MaliBilgiler
{
    public int MaliId { get; set; }

    public string? Policeno { get; set; }

    public decimal? BrutPrim { get; set; }

    public decimal? Bsmv { get; set; }

    public decimal? Ysv { get; set; }

    public decimal? NetPrim { get; set; }

    public decimal? AcenteKomisyonu { get; set; }

    public decimal? Thgf { get; set; }

    public decimal? Gf { get; set; }

    public decimal? Kur { get; set; }

    public bool? SanalPos { get; set; }

    public virtual AsosPolice? PolicenoNavigation { get; set; }
}

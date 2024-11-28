using System;
using System.Collections.Generic;

namespace tetacode.Models;

public partial class Arac
{
    public int AracId { get; set; }

    public string? Policeno { get; set; }

    public string? Plaka { get; set; }

    public string? TarifeKodu { get; set; }

    public string? Marka { get; set; }

    public string? MarkaTipi { get; set; }

    public int? ModelYili { get; set; }

    public string? AracKodu { get; set; }

    public string? Motorno { get; set; }

    public string? Sasino { get; set; }

    public string? KullanimTarzi { get; set; }

    public string? Ruhsatno { get; set; }

    public DateTime? TescilTarihi { get; set; }

    public virtual AsosPolice? PolicenoNavigation { get; set; }
}

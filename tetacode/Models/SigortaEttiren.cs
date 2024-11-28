using System;
using System.Collections.Generic;

namespace tetacode.Models;

public partial class SigortaEttiren
{
    public int SigortaciId { get; set; }

    public string? Policeno { get; set; }

    public string? Tckn { get; set; }

    public string? Ad { get; set; }

    public string? SoyadUnvan { get; set; }

    public string? Adres { get; set; }

    public string? Eposta { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public virtual AsosPolice? PolicenoNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace tetacode.Models;

public partial class Taksitler
{
    public int TaksitId { get; set; }

    public string? Policeno { get; set; }

    public int? Id { get; set; }

    public DateOnly? Vade { get; set; }

    public decimal? Tutar { get; set; }

    public string? OdemeAraci { get; set; }

    public virtual AsosPolice? PolicenoNavigation { get; set; }
}

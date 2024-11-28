using System;
using System.Collections.Generic;

namespace tetacode.Models;

public partial class AsosPolice
{
    public string Policeno { get; set; } = null!;

    public string? Yenilemeno { get; set; }

    public string? Zeyilno { get; set; }

    public string? YenilemeNo { get; set; }

    public string? ZeyilNo { get; set; }

    public string? PoliceDurum { get; set; }

    public string? ZeyilAciklama { get; set; }

    public string? Pb { get; set; }

    public DateOnly? TanzimTarihi { get; set; }

    public DateOnly? BitisTarihi { get; set; }

    public DateOnly? BaslangicTarihi { get; set; }

    public string? UrunAdi { get; set; }

    public string? Daskno { get; set; }

    public string? DaskUavtno { get; set; }

    public string? RizikoSehir { get; set; }

    public string? RizikoIlce { get; set; }

    public string? RizikoAdres { get; set; }

    public virtual ICollection<Arac> Aracs { get; set; } = new List<Arac>();

    public virtual ICollection<MaliBilgiler> MaliBilgilers { get; set; } = new List<MaliBilgiler>();

    public virtual ICollection<SigortaEttiren> SigortaEttirens { get; set; } = new List<SigortaEttiren>();

    public virtual ICollection<Sigortalilar> Sigortalilars { get; set; } = new List<Sigortalilar>();

    public virtual ICollection<Taksitler> Taksitlers { get; set; } = new List<Taksitler>();
}

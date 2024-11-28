using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace tetacode.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arac> Aracs { get; set; }

    public virtual DbSet<AsosPolice> AsosPolices { get; set; }

    public virtual DbSet<MaliBilgiler> MaliBilgilers { get; set; }

    public virtual DbSet<SigortaEttiren> SigortaEttirens { get; set; }

    public virtual DbSet<Sigortalilar> Sigortalilars { get; set; }

    public virtual DbSet<Taksitler> Taksitlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TEH1VL5\\SQLEXPRESS;Database=test2;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arac>(entity =>
        {
            entity.HasKey(e => e.AracId).HasName("PK__ARAC__BE5EE87AD741C25F");

            entity.ToTable("ARAC");

            entity.Property(e => e.AracId).HasColumnName("arac_id");
            entity.Property(e => e.AracKodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ARAC_KODU");
            entity.Property(e => e.KullanimTarzi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("KULLANIM_TARZI");
            entity.Property(e => e.Marka)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARKA");
            entity.Property(e => e.MarkaTipi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MARKA_TIPI");
            entity.Property(e => e.ModelYili).HasColumnName("MODEL_YILI");
            entity.Property(e => e.Motorno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MOTORNO");
            entity.Property(e => e.Plaka)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PLAKA");
            entity.Property(e => e.Policeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policeno");
            entity.Property(e => e.Ruhsatno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RUHSATNO");
            entity.Property(e => e.Sasino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SASINO");
            entity.Property(e => e.TarifeKodu)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TARIFE_KODU");
            entity.Property(e => e.TescilTarihi)
                .HasColumnType("datetime")
                .HasColumnName("TESCIL_TARIHI");

            entity.HasOne(d => d.PolicenoNavigation).WithMany(p => p.Aracs)
                .HasForeignKey(d => d.Policeno)
                .HasConstraintName("FK__ARAC__policeno__4222D4EF");
        });

        modelBuilder.Entity<AsosPolice>(entity =>
        {
            entity.HasKey(e => e.Policeno).HasName("PK__ASOS_POL__F20359C9617EC18C");

            entity.ToTable("ASOS_POLICE");

            entity.Property(e => e.Policeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policeno");
            entity.Property(e => e.BaslangicTarihi).HasColumnName("BASLANGIC_TARIHI");
            entity.Property(e => e.BitisTarihi).HasColumnName("BITIS_TARIHI");
            entity.Property(e => e.DaskUavtno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DASK_UAVTNO");
            entity.Property(e => e.Daskno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DASKNO");
            entity.Property(e => e.Pb)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PB");
            entity.Property(e => e.PoliceDurum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POLICE_DURUM");
            entity.Property(e => e.PoliceDurum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POLICE_NO");
            entity.Property(e => e.RizikoAdres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RIZIKO_ADRES");
            entity.Property(e => e.RizikoIlce)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RIZIKO_ILCE");
            entity.Property(e => e.RizikoSehir)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("RIZIKO_SEHIR");
            entity.Property(e => e.TanzimTarihi).HasColumnName("TANZIM_TARIHI");
            entity.Property(e => e.UrunAdi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("URUN_ADI");
            entity.Property(e => e.YenilemeNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("YENILEME_NO");
            entity.Property(e => e.Yenilemeno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("yenilemeno");
            entity.Property(e => e.ZeyilAciklama)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ZEYIL_ACIKLAMA");
            entity.Property(e => e.ZeyilNo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ZEYIL_NO");
            entity.Property(e => e.Zeyilno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("zeyilno");
        });

        modelBuilder.Entity<MaliBilgiler>(entity =>
        {
            entity.HasKey(e => e.MaliId).HasName("PK__MALI_BIL__A69134029D8F51E7");

            entity.ToTable("MALI_BILGILER");

            entity.Property(e => e.MaliId).HasColumnName("mali_id");
            entity.Property(e => e.AcenteKomisyonu)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("ACENTE_KOMISYONU");
            entity.Property(e => e.BrutPrim)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("BRUT_PRIM");
            entity.Property(e => e.Bsmv)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("BSMV");
            entity.Property(e => e.Gf)
                .HasColumnType("decimal(15, 10)")
                .HasColumnName("GF");
            entity.Property(e => e.Kur)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("KUR");
            entity.Property(e => e.NetPrim)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("NET_PRIM");
            entity.Property(e => e.Policeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policeno");
            entity.Property(e => e.SanalPos).HasColumnName("SANAL_POS");
            entity.Property(e => e.Thgf)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("THGF");
            entity.Property(e => e.Ysv)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("YSV");

            entity.HasOne(d => d.PolicenoNavigation).WithMany(p => p.MaliBilgilers)
                .HasForeignKey(d => d.Policeno)
                .HasConstraintName("FK__MALI_BILG__polic__398D8EEE");
        });

        modelBuilder.Entity<SigortaEttiren>(entity =>
        {
            entity.HasKey(e => e.SigortaciId).HasName("PK__SIGORTA___BBF0F8BAD7D917A7");

            entity.ToTable("SIGORTA_ETTIREN");

            entity.Property(e => e.SigortaciId).HasColumnName("sigortaci_id");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AD");
            entity.Property(e => e.Adres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADRES");
            entity.Property(e => e.DogumTarihi)
                .HasColumnType("datetime")
                .HasColumnName("DOGUM_TARIHI");
            entity.Property(e => e.Eposta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EPOSTA");
            entity.Property(e => e.Policeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policeno");
            entity.Property(e => e.SoyadUnvan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOYAD_UNVAN");
            entity.Property(e => e.Tckn)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TCKN");

            entity.HasOne(d => d.PolicenoNavigation).WithMany(p => p.SigortaEttirens)
                .HasForeignKey(d => d.Policeno)
                .HasConstraintName("FK__SIGORTA_E__polic__3C69FB99");
        });

        modelBuilder.Entity<Sigortalilar>(entity =>
        {
            entity.HasKey(e => e.SigortaliId).HasName("PK__SIGORTAL__64F60082A08849DC");

            entity.ToTable("SIGORTALILAR");

            entity.Property(e => e.SigortaliId).HasColumnName("sigortali_id");
            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AD");
            entity.Property(e => e.Adres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADRES");
            entity.Property(e => e.DogumTarihi)
                .HasColumnType("datetime")
                .HasColumnName("DOGUM_TARIHI");
            entity.Property(e => e.Eposta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EPOSTA");
            entity.Property(e => e.Policeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policeno");
            entity.Property(e => e.SoyadUnvan)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SOYAD_UNVAN");
            entity.Property(e => e.Tamunvan)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tamunvan");
            entity.Property(e => e.Tckn)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("TCKN");

            entity.HasOne(d => d.PolicenoNavigation).WithMany(p => p.Sigortalilars)
                .HasForeignKey(d => d.Policeno)
                .HasConstraintName("FK__SIGORTALI__polic__3F466844");
        });

        modelBuilder.Entity<Taksitler>(entity =>
        {
            entity.HasKey(e => e.TaksitId).HasName("PK__TAKSITLE__23577FD643CE0EC3");

            entity.ToTable("TAKSITLER");

            entity.Property(e => e.TaksitId).HasColumnName("taksit_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OdemeAraci)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ODEME_ARACI");
            entity.Property(e => e.Policeno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("policeno");
            entity.Property(e => e.Tutar)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("TUTAR");
            entity.Property(e => e.Vade).HasColumnName("VADE");

            entity.HasOne(d => d.PolicenoNavigation).WithMany(p => p.Taksitlers)
                .HasForeignKey(d => d.Policeno)
                .HasConstraintName("FK__TAKSITLER__polic__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

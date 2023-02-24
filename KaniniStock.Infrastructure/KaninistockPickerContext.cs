using System;
using System.Collections.Generic;
using KaniniStock.Domain.Models.SourceModels;
using Microsoft.EntityFrameworkCore;

namespace KaniniStock.Infrastructure;
public partial class KaninistockPickerContext : DbContext
{
    public KaninistockPickerContext()
    {

    }
    public KaninistockPickerContext(DbContextOptions<KaninistockPickerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KcompanyDetail> KcompanyDetails { get; set; }

    public virtual DbSet<KcompanyPicker> KcompanyPickers { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=KANINIStockPicker;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KcompanyDetail>(entity =>
        {
            entity.HasKey(e => e.Companycode);

            entity.ToTable("KCompanyDetails");

            entity.Property(e => e.Companycode)
                .HasMaxLength(20)
                .HasColumnName("COMPANYCODE");
            entity.Property(e => e.Cash)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("CASH");
            entity.Property(e => e.Closingshareprice)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("CLOSINGSHAREPRICE");
            entity.Property(e => e.Currenttradingprice)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("CURRENTTRADINGPRICE");
            entity.Property(e => e.Debt)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("DEBT");
            entity.Property(e => e.Dividentyield)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("DIVIDENTYIELD");
            entity.Property(e => e.Enterpricevalue)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("ENTERPRICEVALUE");
            entity.Property(e => e.Facevalue)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("FACEVALUE");
            entity.Property(e => e.Marketcapitalization)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("MARKETCAPITALIZATION");
            entity.Property(e => e.Numberofshares)
                .HasColumnType("text")
                .HasColumnName("NUMBEROFSHARES");
            entity.Property(e => e.Opportunities)
                .HasMaxLength(100)
                .HasColumnName("OPPORTUNITIES");
            entity.Property(e => e.Promoterholding)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("PROMOTERHOLDING");
            entity.Property(e => e.Strength)
                .HasMaxLength(100)
                .HasColumnName("STRENGTH");
            entity.Property(e => e.Threats)
                .HasMaxLength(100)
                .HasColumnName("THREATS");
            entity.Property(e => e.Todayshigh)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("TODAYSHIGH");
            entity.Property(e => e.TodayslOw)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("TODAYSlOW");
            entity.Property(e => e.Weakness)
                .HasMaxLength(100)
                .HasColumnName("WEAKNESS");
            entity.Property(e => e._52whigh)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("52WHIGH");
            entity.Property(e => e._52wlow)
                .HasColumnType("numeric(20, 2)")
                .HasColumnName("52WLOW");
        });

        modelBuilder.Entity<KcompanyPicker>(entity =>
        {
            entity.HasKey(e => e.CompanyCode);

            entity.ToTable("KCompanyPicker");

            entity.Property(e => e.CompanyCode).HasMaxLength(20);
            entity.Property(e => e.CompanyName).HasMaxLength(100);
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__UserLogi__C9F28457B1A18CE2");

            entity.ToTable("UserLogin");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

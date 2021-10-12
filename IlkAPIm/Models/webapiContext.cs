using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace IlkAPIm.Models
{
    public partial class webapiContext : DbContext
    {
        public webapiContext()
        {
        }

        public webapiContext(DbContextOptions<webapiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DersOgrenci> DersOgrencis { get; set; }
        public virtual DbSet<Dersler> Derslers { get; set; }
        public virtual DbSet<Hocalar> Hocalars { get; set; }
        public virtual DbSet<Ogrenciler> Ogrencilers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q65RLAS\\SQLEXPRESS;Initial Catalog=webapi;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<DersOgrenci>(entity =>
            {
                entity.HasKey(e => new { e.AldigiDerslerid, e.DOgrencilerid });

                entity.ToTable("DersOgrenci");

                entity.HasIndex(e => e.DOgrencilerid, "IX_DersOgrenci_dOgrencilerid");

                entity.Property(e => e.AldigiDerslerid).HasColumnName("aldigiDerslerid");

                entity.Property(e => e.DOgrencilerid).HasColumnName("dOgrencilerid");

                entity.HasOne(d => d.AldigiDersler)
                    .WithMany(p => p.DersOgrencis)
                    .HasForeignKey(d => d.AldigiDerslerid);

                entity.HasOne(d => d.DOgrenciler)
                    .WithMany(p => p.DersOgrencis)
                    .HasForeignKey(d => d.DOgrencilerid);
            });

            modelBuilder.Entity<Dersler>(entity =>
            {
                entity.ToTable("Dersler");

                entity.HasIndex(e => e.DHocaid, "IX_Dersler_dHocaid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad).HasColumnName("ad");

                entity.Property(e => e.DHocaid).HasColumnName("dHocaid");

                entity.Property(e => e.DersKodu).HasColumnName("dersKodu");

                entity.Property(e => e.Kontenjan).HasColumnName("kontenjan");

                entity.HasOne(d => d.DHoca)
                    .WithMany(p => p.Derslers)
                    .HasForeignKey(d => d.DHocaid);
            });

            modelBuilder.Entity<Hocalar>(entity =>
            {
                entity.ToTable("Hocalar");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad).HasColumnName("ad");

                entity.Property(e => e.DTarihi).HasColumnName("dTarihi");

                entity.Property(e => e.PersNo).HasColumnName("persNo");

                entity.Property(e => e.Soyad).HasColumnName("soyad");
            });

            modelBuilder.Entity<Ogrenciler>(entity =>
            {
                entity.ToTable("Ogrenciler");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ad).HasColumnName("ad");

                entity.Property(e => e.DTarihi).HasColumnName("dTarihi");

                entity.Property(e => e.OgrNo).HasColumnName("ogrNo");

                entity.Property(e => e.Soyad).HasColumnName("soyad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

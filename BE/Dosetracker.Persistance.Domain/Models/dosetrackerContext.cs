using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Dosetracker.Persistance.Domain.Models
{
    public partial class dosetrackerContext : DbContext
    {
        public dosetrackerContext()
        {
        }

        public dosetrackerContext(DbContextOptions<dosetrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dosetracker> Dosetrackers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=85.95.242.214\\SQLSERVER2014;user=sa;password=Protek2020!!;database=dosetracker;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dosetracker>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dosetracker");

                entity.Property(e => e.Hospitalid)
                    .HasMaxLength(50)
                    .HasColumnName("hospitalid");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Operator)
                    .HasMaxLength(50)
                    .HasColumnName("operator");

                entity.Property(e => e.Patientage).HasColumnName("patientage");

                entity.Property(e => e.Patientsex).HasColumnName("patientsex");

                entity.Property(e => e.Patientsize).HasColumnName("patientsize");

                entity.Property(e => e.Patientweight).HasColumnName("patientweight");

                entity.Property(e => e.Studydate)
                    .HasColumnType("datetime")
                    .HasColumnName("studydate");

                entity.Property(e => e.Studysar).HasColumnName("studysar");

                entity.Property(e => e.Studysequence)
                    .HasMaxLength(10)
                    .HasColumnName("studysequence")
                    .IsFixedLength(true);

                entity.Property(e => e.Vucutkitleendeksi).HasColumnName("vucutkitleendeksi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

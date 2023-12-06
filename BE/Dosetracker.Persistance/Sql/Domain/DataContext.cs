using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MEDLIFE.PERSISTANCE.Data.SQL;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.SqlServer;
using RiseCore.Common;
using Microsoft.Extensions.Logging;
using Dosetracker.Persistance.Domain.Models;

namespace MEDLIFE.PERSISTANCE.DOMAIN.Models
{
    public class DataContext : CommonDbContext
    {
        public static readonly ILoggerFactory consoleLoggerFactory
           = LoggerFactory.Create(builder =>
           {
               builder.AddDebug();
           });

        public bool IsLogging { get; set; }

        public DataContext(bool logging = false)
           : base(/*$"name={LocalSettings.AppName}"*/"")
        {
            IsLogging = logging;
        }
        public virtual DbSet<Dosetracker.Persistance.Domain.Models.Dosetracker> Dosetrackers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (IsLogging)
                    optionsBuilder.UseLoggerFactory(consoleLoggerFactory);
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                var connectionString = AppSettings.GetCurrent().DatabaseSetting.DosetrackerSql;
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dosetracker.Persistance.Domain.Models.Dosetracker>(entity =>
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
        }
    }
}

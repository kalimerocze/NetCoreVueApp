﻿using Microsoft.EntityFrameworkCore;
using VueApp.Models;

namespace VueApp.Context
{
    //musim nainstalovat entity framework
    public class VueAppDbContext : DbContext
    {

        //musime poslat DbContextOptions parametr typu teto tridy
        //v tomto parametru musime poslat database providet mysql slserver a connection string 
        public VueAppDbContext(DbContextOptions<VueAppDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clanek>().ToTable("Clanek", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistorieClanek");
                    o.HasPeriodStart("PlatneOd");
                    o.HasPeriodEnd("PlatneDo");

                });

            });
            modelBuilder.Entity<Odkaz>().ToTable("Odkaz", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistorieOdkaz");
                    o.HasPeriodStart("PlatneOd");
                    o.HasPeriodEnd("PlatneDo");

                });

            });
            modelBuilder.Entity<TypClanku>().ToTable("TypClanku", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistorieTypClanku");
                    o.HasPeriodStart("PlatneOd");
                    o.HasPeriodEnd("PlatneDo");

                });

            });
            modelBuilder.Entity<TypOdkazu>().ToTable("TypOdkazu", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistorieTypOdkazu");
                    o.HasPeriodStart("PlatneOd");
                    o.HasPeriodEnd("PlatneDo");

                });

            });
            modelBuilder.Entity<Soubor>().ToTable("Soubor", c =>
            {
                c.IsTemporal(o =>
                {
                    o.UseHistoryTable("HistorieSoubor");
                    o.HasPeriodStart("PlatneOd");
                    o.HasPeriodEnd("PlatneDo");

                });

            });
        }
        public DbSet<Clanek>? Clanek { get; set; }
        public DbSet<Odkaz>? Odkaz { get; set; }
        public DbSet<Soubor>? Soubor { get; set; }
        public DbSet<TypClanku>? TypClanku { get; set; }
        public DbSet<TypOdkazu>? TypOdkazu { get; set; }
    }
}
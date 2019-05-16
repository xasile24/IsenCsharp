﻿using System;
using System.Collections.Generic;
using System.Text;
using Isen.DotNet.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Isen.DotNet.Library.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Collection des objets du modèle
        public DbSet<City> CityCollection { get; set; }
        public DbSet<Person> PersonCollection { get; set; }
        public DbSet<Club> ClubCollection { get; set; }
        public DbSet<Player> PlayerCollection { get; set; }
        public DbSet<Historic> HistoricCollection { get; set; }


        // Constructeur avec signature obligatoire
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Préciser les tables et relations du modèle
            modelBuilder.Entity<City>()
                .ToTable(nameof(City));
            modelBuilder.Entity<Person>()
                .ToTable(nameof(Person))
                .HasOne(p => p.BornIn)
                .WithMany(c => c.PersonCollection)
                .HasForeignKey(p => p.BornInId)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Club>()
                .ToTable(nameof(Club));
            modelBuilder.Entity<Player>()
                .ToTable(nameof(Player));
            modelBuilder.Entity<Historic>()
                .ToTable(nameof(Historic))
                .HasOne(h => h.HPlayer)
                .WithMany(p => p.HistoricCollection)
                .HasForeignKey(c => c.HPlayerId);
        }
    }
}

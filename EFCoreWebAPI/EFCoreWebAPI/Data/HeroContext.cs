using EFCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace EFCoreWebAPI.Data
{
    public class HeroContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Battle> Battles { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Secretidentity> Secretidentitys { get; set; }
        public DbSet<HeroBattle> HeroBattles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=heroapp;Data Source=DESKTOP-F99HABO\SQLEXPRESS01");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroBattle>(entity =>
            {
                entity.HasKey(e => new { e.BattleId, e.HeroId });
            });
        }
    }
}

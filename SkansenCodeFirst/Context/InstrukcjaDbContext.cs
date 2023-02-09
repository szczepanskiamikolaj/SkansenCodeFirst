using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkansenCodeFirst.Model;
using SkansenCodeFirst.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSZcw.Context
{
    public class InstrukcjaDbContext : IdentityDbContext<User>
    {
        public InstrukcjaDbContext(DbContextOptions<InstrukcjaDbContext> options) : base(options)
        { }
        public DbSet<Konserwacja> CzynnosciKonserwacyjne { get; set; }
        public DbSet<Inwentaryzacja> Inwentaryzacje { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Produkt> Produkty { get; set; }
        public DbSet<Sprzedaz> Sprzedaze { get; set; }
        public DbSet<Zabytek> Zabytki { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sprzedaz>() // one to many
            .HasOne(s => s.Produkt)
            .WithMany(p => p.Sprzedaze)
            .HasForeignKey(s => s.ProduktId);

            modelBuilder.Entity<Sprzedaz>() // one to many
            .HasOne(s => s.Pracownik)
            .WithMany(pr => pr.Pracownicy)
            .HasForeignKey(s => s.PracownikId);

            modelBuilder.Entity<Inwentaryzacja>() // one to many
            .HasOne(i => i.Pracownik)
            .WithMany(pr => pr.Inwentaryzacje)
            .HasForeignKey(i => i.PracownikId);

            modelBuilder.Entity<Inwentaryzacja>() // one to many
            .HasOne(i => i.Zabytek)
            .WithMany(z => z.Inwentaryzacje)
            .HasForeignKey(i => i.ZabytekId);

            modelBuilder.Entity<Konserwacja>() // one to many
            .HasOne(c => c.Zabytek)
            .WithMany(z => z.Konserwacje)
            .HasForeignKey(c => c.ZabytekId);

            modelBuilder.Entity<Konserwacja>() // one to many
            .HasOne(c => c.Pracownik)
            .WithMany(p => p.Czynnosci)
            .HasForeignKey(c => c.PracownikId);
            base.OnModelCreating(modelBuilder);

        }
    }
}

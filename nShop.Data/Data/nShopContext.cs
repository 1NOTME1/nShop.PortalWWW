using Microsoft.EntityFrameworkCore;
using nShop.Data.Data.CMS;
using nShop.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data
{
    public class nShopContext : DbContext
    {
        public nShopContext(DbContextOptions<nShopContext> options)
            : base(options)
        {
        }

        public DbSet<Aktualnosc> Aktualnosc { get; set; }
        public DbSet<Strona> Strona { get; set; }
        public DbSet<Kategoria> Kategoria { get; set; }
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<Producent> Producent { get; set; }
        public DbSet<Uzytkownik> Uzytkownik { get; set; }
        public DbSet<Rola> Rola { get; set; }
        public DbSet<Recenzja> Recenzja { get; set; }
        public DbSet<Zamowienie> Zamowienie { get; set; }
        public DbSet<ElementZamowienia> ElementZamowienia { get; set; }
        public DbSet<StatusZamowienia> StatusZamowienia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ElementZamowienia>()
                .Property(e => e.CenaJednostkowa)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Zamowienie>()
                .Property(e => e.Suma)
                .HasPrecision(18, 2);
        }


    }
}

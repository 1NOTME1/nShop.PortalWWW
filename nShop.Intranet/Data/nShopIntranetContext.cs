using Microsoft.EntityFrameworkCore;
using nShop.Intranet.Models.CMS;
using nShop.Intranet.Models.Sklep;

namespace nShop.Intranet.Data
{
    public class nShopIntranetContext : DbContext
    {
        public nShopIntranetContext(DbContextOptions<nShopIntranetContext> options)
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
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Zamowienie>()
                .Property(z => z.Suma)
                .HasColumnType("decimal(18, 2)");
        }
    }
}

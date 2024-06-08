using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nShop.Data.Data.Sklep;

namespace nShop.PortalWWW.Data
{
    public class nShopPortalWWWContext : DbContext
    {
        public nShopPortalWWWContext (DbContextOptions<nShopPortalWWWContext> options)
            : base(options)
        {
        }

        public DbSet<nShop.Data.Data.Sklep.Zamowienie> Zamowienie { get; set; } = default!;
    }
}

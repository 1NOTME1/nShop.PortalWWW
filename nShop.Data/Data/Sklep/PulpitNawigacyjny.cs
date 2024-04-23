using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nShop.Data.Data.Sklep
{
    public class PulpitNawigacyjny
    {
        public int LiczbaZamowien { get; set; }
        public decimal LacznaKwotaSprzedazy { get; set; }
        public List<ProduktInfo> ProduktyWymagajaceUwagi { get; set; } = new List<ProduktInfo>();
    }

    public class ProduktInfo
    {
        public string Nazwa { get; set; }
        public int IloscNaMagazynie { get; set; }
    }
}

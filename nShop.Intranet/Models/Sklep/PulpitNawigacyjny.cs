namespace nShop.Intranet.Models.Sklep
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

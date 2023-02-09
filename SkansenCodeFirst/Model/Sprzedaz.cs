using System;

namespace SkansenCodeFirst.Model
{
    public class Sprzedaz
    {
        public int SprzedazId { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataSprzedazy { get; set; }
        public int ProduktId { get; set; }
        public int PracownikId { get; set; }
        public virtual Produkt Produkt { get; set; }
        public virtual Pracownik Pracownik { get; set; }

    }
}

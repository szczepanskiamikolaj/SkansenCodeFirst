using System;

namespace SkansenCodeFirst.Model
{
    public class Inwentaryzacja
    {
        public int InwentaryzacjaId { get; set; }
        public int PracownikId { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public int ZabytekId { get; set; }
        public virtual Zabytek Zabytek { get; set; }
        public DateTime DataRaportu { get; set; }
        public string Komentarz { get; set; }
        public bool WymagaRenowacji { get; set; }
    }
}

using System;

namespace SkansenCodeFirst.Model
{
    public class Konserwacja
    {
        public int KonserwacjaId { get; set; }
        public DateTime KonserwacjaData { get; set; }
        public int PracownikId { get; set; }
        public virtual Pracownik Pracownik { get; set; }
        public int ZabytekId { get; set; }
        public virtual Zabytek Zabytek { get; set; }
        public string KonserwacjaKomentarz { get;}
    }
}

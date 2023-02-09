using AutoMapper.Internal.Mappers;
using System.Collections.Generic;
using System.Data;
using System.Text.Json.Serialization;

namespace SkansenCodeFirst.Model
{
    public class Pracownik
    {
        public int PracownikId { get; set; }
        public string Imie { get;set; }
        public string Nazwisko { get; set; }
        public string Telefon { get; set; }
        public string PortretUrl { get; set; }
        [JsonIgnore]
        public ICollection<Konserwacja> Czynnosci { get; set; }
        [JsonIgnore]
        public ICollection<Sprzedaz> Pracownicy { get; set; }
        [JsonIgnore]
        public ICollection<Inwentaryzacja> Inwentaryzacje { get; set; }
        public override string ToString()
        {
            return Imie + " " + Nazwisko;
        }
    }
}

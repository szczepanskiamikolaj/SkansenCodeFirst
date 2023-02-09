using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SkansenCodeFirst.Model
{
    public class Zabytek
    {
        public int ZabytekId { get; set; }
        public string ZabytekNazwa { get; set; }
        public string ObrazUrl { get; set; }
        public bool WymagaRenowacji { get; set; }
        [JsonIgnore]
        public virtual ICollection<Inwentaryzacja> Inwentaryzacje { get; set; }
        [JsonIgnore]
        public virtual ICollection<Konserwacja> Konserwacje { get; set; }

    }
}

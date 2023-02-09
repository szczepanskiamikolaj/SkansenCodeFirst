using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SkansenCodeFirst.Model
{
    public class Produkt
    {
        public int ProduktId { get; set; }
        public string ProduktName { get;set; }
        public float ProduktCena { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sprzedaz> Sprzedaze { get; set; }
    }
}

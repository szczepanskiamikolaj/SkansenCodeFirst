using SkansenCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkansenCodeFirst.Interface
{
    public interface IProduktRepository
    {
        Produkt Get(int ProduktId);
        IEnumerable<Produkt> GetAll();
        Produkt Post(Produkt newProdukt);
        Produkt Put(Produkt updatedProdukt);
        Produkt Delete(int ProduktId);
    }
}

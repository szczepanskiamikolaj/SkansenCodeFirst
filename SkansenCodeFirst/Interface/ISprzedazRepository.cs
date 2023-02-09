using SkansenCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkansenCodeFirst.Interface
{
    public interface ISprzedazRepository
    {
        Sprzedaz Get(int SprzedazId);
        IEnumerable<Sprzedaz> GetAll();
        Sprzedaz Post(Sprzedaz newSprzedaz);
        Sprzedaz Put(Sprzedaz updatedSprzedaz);
        Sprzedaz Delete(int SprzedazId);
    }
}

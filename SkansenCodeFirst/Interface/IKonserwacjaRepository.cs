using SkansenCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkansenCodeFirst.Interface
{
    public interface IKonserwacjaRepository
    {
        Konserwacja Get(int KonserwacjaId);
        IEnumerable<Konserwacja> GetAll();
        Konserwacja Post(Konserwacja newKonserwacja);
        Konserwacja Put(Konserwacja updatedKonserwacja);
        Konserwacja Delete(int KonserwacjaId);
    }
}

using SkansenCodeFirst.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkansenCodeFirst.Interface
{
    public interface IInwentaryzacjaRepository
    {
        Inwentaryzacja Get(int InwentaryzacjaId);
        IEnumerable<Inwentaryzacja> GetAll();
        Inwentaryzacja Post(Inwentaryzacja newInwentaryzacja);
        Inwentaryzacja Put(Inwentaryzacja updatedInwentaryzacja);
        Inwentaryzacja Delete(int InwentaryzacjaId);
    }
}

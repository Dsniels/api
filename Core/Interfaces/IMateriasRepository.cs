using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMateriasRepository
    {
        Task<Materia> getMateriaByIdAsnc(int id);
        Task<IReadOnlyList<Materia>> getMateriasAsync();
        Task<IReadOnlyList<Materia>> getMateriasWhereProfesor(int id);
        Task<IReadOnlyList<Materia>> getMateriasWhereCarrera(int id);
        Task<IReadOnlyList<Materia>> getMateriasWhereProfesorAndCarrera(int id, int carreraID);

    }
}

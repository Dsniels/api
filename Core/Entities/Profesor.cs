using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Profesor : Base
    {
        public string Nombre { get; set; }
        public List<Materia> Materias { get; set; }
        public List<Carrera> Carreras { get; set; }

    }
}

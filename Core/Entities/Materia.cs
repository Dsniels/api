using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Materia : Base
    {
        public string Nombre { get; set; }
        public ICollection<string> Carreras { get; set; }
        public ICollection<string> Profesores { get; set; }
    }
}

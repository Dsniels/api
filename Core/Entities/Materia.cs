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
        public List<string> Carreras { get; set; }
        public List<string> Profesores { get; set; }
    }
}

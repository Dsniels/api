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
        public  Profesor Profesor { get; set; }
        public  Carrera Carrera { get; set; } 
    }
}

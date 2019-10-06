using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class Inquilino
    {
        public int Id { get; set; }

        public String Dni { get; set; }

        public String Apellido { get; set; }

        public String Nombre { get; set; }

        public String Direccion { get; set; }

        public String Telefono { get; set; }
    }
}

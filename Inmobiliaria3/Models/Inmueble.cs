using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class Inmueble
    {
        public int Id { get; set; }

        public String Direccion { get; set; }

        public int Ambientes { get; set; }

        public String Tipo { get; set; }

        public String Uso { get; set; }

        public double Precio { get; set; }

        public bool Disponible { get; set; }

        public Propietario Propietario { get; set; }
    }
}

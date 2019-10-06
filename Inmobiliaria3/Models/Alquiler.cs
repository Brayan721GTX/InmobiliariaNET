using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class Alquiler
    {
        public int Id { get; set; }

        public double Precio { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public Inquilino Inquilino { get; set; }

        public Inmueble Inmueble { get; set; }
    }
}

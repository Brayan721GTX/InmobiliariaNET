using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria3.Models
{
    public class Pagos
    {
        public int Id { get; set; }

        public int NroPago { get; set; }

        public DateTime Fecha { get; set; }

        public double Importe { get; set; }

        public Alquiler Alquiler { get; set; }
    }
}

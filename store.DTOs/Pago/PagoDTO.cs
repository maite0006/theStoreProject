using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.Pago
{
    public class PagoDTO
    {
        public decimal Monto { get; set; }
        public string Metodo { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaPago { get; set; }
    }
}

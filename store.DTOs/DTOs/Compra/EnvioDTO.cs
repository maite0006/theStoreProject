using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.DTOs.DTOs.Compra
{
    public class EnvioDTO
    {
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }
        public string MetodoEnvio { get; set; }
    }
}

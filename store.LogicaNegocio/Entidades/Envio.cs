using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store.LogicaNegocio.Entidades
{
    public class Envio
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string CodigoPostal { get; set; }
        public string MetodoEnvio { get; set; } // ej: “Estándar”, “Express”
        public DateTime FechaEnvio { get; set; }
        public int CompraId { get; set; }   // FK
        public Compra Compra { get; set; }

        public Envio() { }
    }
}

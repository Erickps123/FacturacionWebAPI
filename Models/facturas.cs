using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionWebApi.Models
{
    public class facturas
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string NombreVendedor { get; set; }
        public string Telefono { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }

    }
}

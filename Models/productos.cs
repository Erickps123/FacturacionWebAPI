using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionWebApi.Models
{
    public class productos
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string Fecha_caducidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double PrecioTotal { get; set; }

    }
}

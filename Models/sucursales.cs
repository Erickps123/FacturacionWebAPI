using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionWebApi.Models
{
    public class sucursales
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public string Telefono { get; set; }
    }
}

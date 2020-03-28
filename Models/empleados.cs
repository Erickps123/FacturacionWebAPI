using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionWebApi.Models
{
    public class empleados
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha_Nac { get; set; }
        public string Fecha_Ing { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Puesto { get; set; }
        public string Sexo { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionWebApi.Models
{
    public class usuarios
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Area { get; set; }
        public string NombredelArea { get; set; }

    }
}

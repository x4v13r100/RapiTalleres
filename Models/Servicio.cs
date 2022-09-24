using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTalleres.Models
{
    public class Servicio
    {   [Key]
        public int ServicioID { get; set; }
        [Required(ErrorMessage = "Invalid Tipo")]
        public String Tipo { get; set; }
        [Required(ErrorMessage = "Invalid Valor")]

        public Double Valor { get; set; }

        public ICollection<Cita> Citas { get; set; }

    }
}
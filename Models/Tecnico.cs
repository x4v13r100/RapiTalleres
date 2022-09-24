using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTalleres.Models
{
    public class Tecnico
    {   [Key]
        public int TecnicoID { get; set; }
        [Required(ErrorMessage = "Invalid Name")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Invalid Apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Invalid Contacto")]
        public string Contacto { get; set; }
        [Required(ErrorMessage = "Invalid Info")]
        public string NivelAcademico { get; set; }

        public ICollection<Cita> Citas { get; set; }
    }
}
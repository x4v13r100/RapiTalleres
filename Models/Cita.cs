using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTalleres.Models
{
    public class Cita
    {
        public int CitaID { get; set; }
        public int TecnicoID { get; set; }
        public int ClienteID { get; set; }
        public int ServicioID { get; set; }
        public Tecnico Tecnico { get; set; }
        public Cliente Cliente { get; set; }
        public Servicio Servicio { get; set; }
    }
}
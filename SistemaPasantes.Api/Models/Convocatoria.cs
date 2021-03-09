using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPasantes.Api.Models
{
    public class Convocatoria
    {
        public int ID { get; set; }

        public string Titulo { get; set; }

        public int Cupo { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaCierre { get; set; }

        public bool Terminada => DateTime.Now >= FechaCierre;
    }
}

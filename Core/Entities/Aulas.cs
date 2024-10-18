using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace PruebaTecnicaAPI.Modelos
{
    public class Aula
    {
        public int AulaID { get; set; }
        public string NombreAula { get; set; }
        public int Capacidad { get; set; }
        public int? DocenteID { get; set; }

        // Relaciones
        public Docente Docente { get; set; }
        public ICollection<Alumno> Alumnos { get; set; }
    }
}

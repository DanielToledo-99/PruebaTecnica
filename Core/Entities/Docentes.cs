using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaAPI.Modelos
{
    public class Docente
    {
        public int DocenteID { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        // Relación con Aula
        public ICollection<Aula> Aulas { get; set; }
    }
}

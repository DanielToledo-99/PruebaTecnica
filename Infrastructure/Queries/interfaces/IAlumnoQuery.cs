using Core.Entities;

namespace Infrastructure.Queries.interfaces
{
    public interface IAlumnoQuery
    {
        Task<IEnumerable<dynamic>> ListarAlumnos();
        Task CrearAlumno();
        Task ActualizarAlumno(Alumno alumno);
        Task EliminarAlumno(int idAlumno);
    }
}

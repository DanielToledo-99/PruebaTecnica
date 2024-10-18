using Core.Entities;
using Infrastructure.Queries.interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Queries
{
    public class AlumnoQuery : IAlumnoQuery
    {
        private readonly string ConnectionString;
        public AlumnoQuery(IConfiguration configuration)
        {
            //Deberá modificar la cadena de conexión antes de ejecutar

            ConnectionString = ConfigurationExtensions.GetConnectionString(configuration, "PruebaTecnicaDB");
        }
        public Task ActualizarAlumno(Alumno alumno)
        {
            /*
             * Ejemplo guía
             * using SqlConnection conn = new(ConnectionString);
             * var param = new DynamicParameters();
             * param.Add("@IdAlumno",alumno.IdAlumno)
             * 
             * await conn.QueryAsync("spActualizarAlumno", param, commandType: CommandType.StoredProcedure);
             */
            throw new NotImplementedException();
        }

        public Task CrearAlumno()
        {
            throw new NotImplementedException();
        }

        public Task EliminarAlumno(int idAlumno)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<dynamic>> ListarAlumnos()
        {
            throw new NotImplementedException();
        }
    }
}

using Dapper;
using Microsoft.Data.SqlClient;
using RepasoApp.Models;

namespace RepasoApp.Services
{
    public interface IExperienciaLaboralRepository
    {
        Task Registrar(ExperienciaLaboral experienciaLaboral);
        Task<IEnumerable<ExperienciaLaboral>> Listar();
        Task<ExperienciaLaboral> BuscarPorId(long id);
    }

    public class ExperienciaLaboralRepository : IExperienciaLaboralRepository
    {
        private readonly string _connectionString;

        public ExperienciaLaboralRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Registrar(ExperienciaLaboral experienciaLaboral)
        {
            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<long>(
                @"INSERT INTO ExperienciaLaboral(Cargo, NombreEmpresa, Descripcion, TipoEmpleoId, EntidadFederativaId)
                 VALUES (@Cargo, @NombreEmpresa, @Descripcion, @TipoEmpleoId, @EntidadFederativaId);SELECT SCOPE_IDENTITY();", experienciaLaboral);
            experienciaLaboral.Id = id;
        }

        public async Task<ExperienciaLaboral> BuscarPorId(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<ExperienciaLaboral>(
                @"SELECT X.Id, X.Cargo, X.NombreEmpresa, X.Descripcion 
                FROM ExperienciaLaboral AS X 
                INNER JOIN TipoEmpleo AS T 
                ON X.TipoEmpleoId = T.Id
                WHERE X.Id = @Id", new { id });
        }

        public async Task<IEnumerable<ExperienciaLaboral>> Listar()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<ExperienciaLaboral>(
                @"SELECT X.*, T.Id FROM ExperienciaLaboral AS X 
                INNER JOIN TipoEmpleo AS T 
                ON X.TipoEmpleoId = T.Id
                ORDER BY X.Id DESC;");
        }

    }
}
using Dapper;
using Microsoft.Data.SqlClient;
using RepasoApp.Models;

namespace RepasoApp.Services
{
    public interface ITipoEmpleoRepository
    {
        Task Registrar(TipoEmpleo tipoEmpleo);
        Task<IEnumerable<TipoEmpleo>> Listar();
        Task Actualizar(TipoEmpleo tipoEmpleo);
        Task<TipoEmpleo> BuscarPorId(long id);
        Task Eliminar(long id);
    }

    public class TipoEmpleoRepository : ITipoEmpleoRepository
    {
        private readonly string _connectionString;

        public TipoEmpleoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Registrar(TipoEmpleo tipoEmpleo)
        {
            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<long>($@"INSERT INTO TipoEmpleo(Nombre) VALUES (@Nombre);SELECT SCOPE_IDENTITY();", tipoEmpleo);
            tipoEmpleo.Id = id;
        }

        public async Task<IEnumerable<TipoEmpleo>> Listar()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<TipoEmpleo>("SELECT Id, Nombre FROM TipoEmpleo ORDER BY Id DESC;");
        }

        public async Task Actualizar(TipoEmpleo tipoEmpleo)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(@"UPDATE TipoEmpleo SET Nombre = @Nombre WHERE Id = @Id", tipoEmpleo);
        }

        public async Task<TipoEmpleo> BuscarPorId(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstAsync<TipoEmpleo>(@"SELECT Id, Nombre FROM TipoEmpleo WHERE Id = @Id", new { id });
        }

        public async Task Eliminar(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(@"DELETE FROM TipoEmpleo WHERE Id = @Id", new { id });
        }

    }
}
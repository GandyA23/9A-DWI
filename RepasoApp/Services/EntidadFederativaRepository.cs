using Dapper;
using Microsoft.Data.SqlClient;
using RepasoApp.Models;

namespace RepasoApp.Services
{
    public interface IEntidadFederativaRepository
    {
        Task<IEnumerable<EntidadFederativa>> Listar();
        Task<EntidadFederativa> BuscarPorId(long id);
    }

    public class EntidadFederativaRepository : IEntidadFederativaRepository
    {
        private readonly string _connectionString;

        public EntidadFederativaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<EntidadFederativa>> Listar()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<EntidadFederativa>("SELECT Id, Nombre FROM EntidadFederativa ORDER BY Nombre ASC;");
        }

        public async Task<EntidadFederativa> BuscarPorId(long id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstAsync<EntidadFederativa>(@"SELECT Id, Nombre FROM EntidadFederativa WHERE Id = @Id", new { id });
        }
    }
}
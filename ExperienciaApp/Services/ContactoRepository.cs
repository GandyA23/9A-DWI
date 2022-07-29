using Dapper;
using ExperienciaApp.Models;
using Microsoft.Data.SqlClient;

namespace ExperienciaApp.Services {
    public interface IContactoRepository {
        // Implementar método asícncrono
        Task Registrar(Contacto contacto);
        Task<IEnumerable<Contacto>> Listar();

        Task Actualizar(Contacto contacto);

        Task<Contacto> BuscarPorId(long id);

        Task Eliminar(long id);
    }


    public class ContactoRepository : IContactoRepository {
        private readonly string _connectionString;

        public ContactoRepository(IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnections");
        }

        public async Task Registrar(Contacto contacto) {
            using var connection = new SqlConnection(_connectionString);
            // var id = connection.QuerySingle<int>($@"INSERT INTO Contacto(Nombre, Email, Telefono, Edad) VALUES (@Nombre, @Email, @Telefono, @Edad); SELECT SCOPE_IDENTITY(); ", contacto);
            var id = await connection.QuerySingleAsync<long>(
                $@"INSERT INTO Contacto(Nombre, Email, Telefono, Edad) VALUES (@Nombre, @Email, @Telefono, @Edad); SELECT SCOPE_IDENTITY(); ",
                contacto);
            Console.WriteLine($"ID DE LA INSERCIÓN: {id}");
        }

        public async Task<IEnumerable<Contacto>> Listar() {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Contacto>(
                $@"SELECT Id, Nombre, Email, Telefono, Edad FROM Contacto;");
        }

        public async Task Actualizar(Contacto contacto) {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(
                $@"UPDATE Contacto SET Nombre = @Nombre, Edad = @Edad, Email = @Email, Telefono = @Telefono WHERE Id = @Id;",
                contacto);
        }

        public async Task<Contacto> BuscarPorId(long id) {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstAsync<Contacto>($@"SELECT * FROM Contacto  WHERE Id = @Id", new { id });
        }

        public async Task Eliminar(long id) {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync($@"DELETE FROM Contacto WHERE Id = @Id", new { id });
        }
    }
}

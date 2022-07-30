using Dapper;
using Microsoft.Data.SqlClient;
using RepasoApp.Models;

namespace RepasoApp.Service
{
    public interface IContactoRepository
    {
        Task Registrar(Contacto contacto);
        Task<IEnumerable<Contacto>> Listar();
        Task Actualizar(Contacto contacto);
        Task<Contacto> BuscarPorId(int id);
        Task Eliminar(int id);
        Task<bool> VerificarExisteCorreo(string? correoElectronico);

        Task<bool> VerificarExisteTelefono(string? Telefono, int Id);
    }

    public class ContactoRepository : IContactoRepository
    {
        private readonly string _connectionString;

        public ContactoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Actualizar(Contacto contacto)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(@"UPDATE Contacto SET Nombre = @Nombre, Edad = @Edad, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono WHERE Id = @Id", contacto);
        }

        public async Task<Contacto> BuscarPorId(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryFirstAsync<Contacto>(@"SELECT Id, Nombre, Edad, CorreoElectronico, Telefono FROM Contacto WHERE Id = @Id", new { id });
        }

        public async Task Eliminar(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.ExecuteAsync(@"DELETE FROM Contacto WHERE Id = @Id", new { id });
        }


        public async Task<IEnumerable<Contacto>> Listar()
        {
            using var connection = new SqlConnection(_connectionString);
            return await connection.QueryAsync<Contacto>("SELECT Id, Nombre, CorreoElectronico, Telefono, Edad FROM Contacto;");
        }

        public async Task Registrar(Contacto contacto)
        {
            using var connection = new SqlConnection(_connectionString);
            var id = await connection.QuerySingleAsync<int>($@"INSERT INTO Contacto(Nombre, CorreoElectronico, Telefono, Edad) VALUES (@Nombre, @CorreoElectronico, @Telefono, @Edad);SELECT SCOPE_IDENTITY();", contacto);
            Console.WriteLine("Id registrado: " + id);
        }

        public async Task<bool> VerificarExisteCorreo(string? correoElectronico)
        {
            using var connection = new SqlConnection(_connectionString);
            var existeCorreo = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM Contacto WHERE CorreoElectronico = @CorreoElectronico", new { correoElectronico}); //int = 0 por defecto, cuando no lo encuentra
            return existeCorreo == 1;
        }

        public async Task<bool> VerificarExisteTelefono(string? Telefono, int Id)
        {
            using var connection = new SqlConnection(_connectionString);
            var existeTelefono = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM Contacto WHERE Telefono = @Telefono AND Id != @Id;", new { Telefono, Id }); //int = 0 por defecto, cuando no lo encuentra
            return existeTelefono == 1;
        }
    }
}

using Dapper;
using ExperienciaApp.Models;
using Microsoft.Data.SqlClient;

namespace ExperienciaApp.Services {
    public interface IContactoRepository {
        // Función asíncrona en C#
        // Retorno del objeto Task
        Task Registrar(Contacto contacto);
        Task<IEnumerable<Contacto>> Listar();
    }

    public class ContactoRepository : IContactoRepository {
        private readonly string _connectionString;

        // Clase con inicialización de la cariable de conexión
        public ContactoRepository (IConfiguration configuration) {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<IEnumerable<Contacto>> Listar() {
            throw new NotImplementedException();
        }

        public async Task Registrar(Contacto contacto) {
            using var connection = new SqlConnection(_connectionString);
            // Realiza una inserción y consulta el id del último registro
            var id = await connection.QuerySingleAsync<int>($@"INSERT INTO Contacto(Nombre, Edad, Email, Telefono) VALUES (@Nombre, @Edad, @Email, @Telefono); SELECT SCOPE_IDENTITY();", contacto);
            Console.WriteLine($"Id registrado: {id}");
        }
    }
}
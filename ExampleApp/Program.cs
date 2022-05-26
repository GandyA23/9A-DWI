var builder = WebApplication.CreateBuilder(args);

// Haz que la aplicación se vuelva un MVC
var services = builder.Services;
services.AddMvc();

var app = builder.Build();

// Mapeado de rutas
// app.MapGet("/hello", () => "Hello World!");
// app.MapGet("/message", () => "Test message");

// Habilita las peticiones HTTP
app.UseHttpsRedirection();

// Para archivos típicos (como index.html) y no sea necesario colocar el nombre del archivo en la ruta y mejor colocar su ruta típica.
app.UseDefaultFiles();

// Has uso de los archivos estáticos que se encuentran dentro de la carpeta wwwroot
app.UseStaticFiles();

// Habilita el enrutamiento
app.UseRouting();

// Habilita la sesión
app.UseAuthorization();

// Mapeo estático (Se asigna a AppController como default y también la acción de Index en caso de que no la mencionan en la ruta)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=App}/{action=Index}/{id?}"
);

app.Run();

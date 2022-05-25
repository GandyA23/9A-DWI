var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Mapeado de rutas
app.MapGet("/hello", () => "Hello World!");
app.MapGet("/message", () => "Test message");

// Para archivos típicos (como index.html) y no sea necesario colocar el nombre del archivo en la ruta y mejor colocar su ruta típica.
app.UseDefaultFiles();

// Has uso de los archivos estáticos que se encuentran dentro de la carpeta wwwroot
app.UseStaticFiles();

app.Run();

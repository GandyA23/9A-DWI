using RepasoApp.Service;
using RepasoApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IContactoRepository, ContactoRepository>();
builder.Services.AddTransient<ITipoEmpleoRepository, TipoEmpleoRepository>();
builder.Services.AddTransient<IExperienciaLaboralRepository, ExperienciaLaboralRepository>();
builder.Services.AddTransient<IEntidadFederativaRepository, EntidadFederativaRepository>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

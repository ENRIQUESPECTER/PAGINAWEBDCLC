using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder;
using CRUDCORE.Controllers;
using CRUDCORE.Datos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


//Metodo Globalizacion
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

const string CulturaPorDefecto = "es";
var CulturaSoportadas = new[]
{
    new CultureInfo(CulturaPorDefecto),
    new CultureInfo("en"),
    new CultureInfo("ja")
};

builder.Services.Configure<RequestLocalizationOptions>(opciones =>
{
    opciones.DefaultRequestCulture = new RequestCulture(CulturaPorDefecto);
    opciones.SupportedCultures = CulturaSoportadas;
    opciones.SupportedUICultures = CulturaSoportadas;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

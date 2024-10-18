using EXAMEN_U1_1_Lenguajes;
using EXAMEN_U1_1_Lenguajes.Database;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

using ( var scope = app.Services.CreateScope()) 
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<RequestforPermitsDbContext>();
        await RequestforPermitsSeeder.LoadDataAsync(context, loggerFactory);
    }
    catch (Exception ex) 
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "Error al Ejecutar el Seed de Datos");    
    }
}

app.Run();
using EXAMEN_U1_1_Lenguajes.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EXAMEN_U1_1_Lenguajes.Database
{
    public class RequestforPermitsSeeder
    {
        public static async Task LoadDataAsync(RequestforPermitsDbContext context, ILoggerFactory loggerFactory) 
        {
            try 
            {
                await LoadEmpleadoAsync(context, loggerFactory);
            }
             catch (Exception e) 
            {
                var logger = loggerFactory.CreateLogger<RequestforPermitsSeeder>();
                logger.LogError(e, "Error inicializando la data del API");
            }
        }
        public static async Task LoadEmpleadoAsync(RequestforPermitsDbContext context, ILoggerFactory loggerFactory)
        {
            try 
            {
                var jsonFilePath = "SeedData/Empleado.json";        
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var Empleados = JsonConvert.DeserializeObject<List<EmpleadoEntity>>(jsonContent) ?? new List<EmpleadoEntity>();
                
                if (!await context.Empleados.AnyAsync())
                {
                    await context.Empleados.AddRangeAsync(Empleados);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e) 
            {
                var logger = loggerFactory.CreateLogger<RequestforPermitsSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed Empleado");
            }
        }
        public static async Task LoadAdministraitorAsync(RequestforPermitsDbContext context, ILoggerFactory loggerFactory) 
        {
            try
            {
                var jsonFilePath = "SeedData/Administraitor.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var Administraitors = JsonConvert.DeserializeObject<List<AdministraitorEntity>>(jsonContent) ?? new List<AdministraitorEntity>();
            
                if (!await context.Administraitors.AnyAsync()) 
                {
                    await context.Administraitors.AddRangeAsync(Administraitors);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e) 
            {
                var logger = loggerFactory.CreateLogger<RequestforPermitsSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed Empleado");
            }
        }

    }
}

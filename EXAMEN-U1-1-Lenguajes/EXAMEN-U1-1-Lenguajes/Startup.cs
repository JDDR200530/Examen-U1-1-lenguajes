using EXAMEN_U1_1_Lenguajes.Database;
using EXAMEN_U1_1_Lenguajes.Database.Dto.Helpers;
using EXAMEN_U1_1_Lenguajes.Service;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN_U1_1_Lenguajes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add DbContex
            services.AddDbContext<RequestforPermitsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Add custom services
            services.AddTransient<IAuthService, AuthService>();

            //Add Automapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddCors(opt =>
            {
                var allowURLS = Configuration.GetSection("AllowURLS").Get<string[]>();
                opt.AddPolicy("CorsPolicy", builder => builder.WithOrigins(allowURLS).AllowAnyMethod().
                AllowAnyHeader().
                AllowCredentials());


            });


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using EXAMEN_U1_1_Lenguajes.Entity;
using EXAMEN_U1_1_Lenguajes.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN_U1_1_Lenguajes.Database
{
    public class RequestforPermitsDbContext : DbContext
    {
        private readonly IAuthService _authService;

        public RequestforPermitsDbContext(DbContextOptions<RequestforPermitsDbContext> options, IAuthService authService) : base(options)
        {
            _authService = authService;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is Request_for_Permission && (e.State == EntityState.Added || e.State == EntityState.Modified));
            //foreach (var entry in entries) 
            //{
            //    var entity = entry.Entity; as Request_for_Permission;
            //    if (entity != null && entry.State == EntityState.Added)
            //    {
            //        ent
            //    }
            //}
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<EmpleadoEntity>Empleados { get; set; }
        public DbSet<Administraitor>Administraitors { get; set; }
        public DbSet<Request_for_Permission>Request_For_Permissions { get; set; }
    }
}

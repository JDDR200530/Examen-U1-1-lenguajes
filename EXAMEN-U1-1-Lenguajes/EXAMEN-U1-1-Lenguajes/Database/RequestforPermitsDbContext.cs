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
            var entries = ChangeTracker.Entries().Where(e => e.Entity is PermisosEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
           
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermisosEntity>()
                .Property(p => p.Status)
                .HasConversion<int>(); 
        }

        public DbSet<EmpleadoEntity>Empleados { get; set; }
        public DbSet<AdministraitorEntity>Administraitors { get; set; }
        public DbSet<PermisosEntity>Permissions { get; set; }
       
    }
}

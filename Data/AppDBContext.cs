using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace WebApplication1.Data
{
	public class AppDBContext : DbContext
	{
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
           
        }

        public DbSet<Empleado> Empleados { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Empleado>(tb => {
				tb.HasKey(col => col.IdEmpleado);

				tb.Property(col => col.IdEmpleado)
				.UseIdentityColumn()
				.ValueGeneratedOnAdd();

				tb.Property(col => col.NombreComlpeto).HasMaxLength(50);
				tb.Property(col => col.Correo).HasMaxLength(50);
			});

			modelBuilder.Entity<Empleado>().ToTable("Empleado");
		}
	}
}

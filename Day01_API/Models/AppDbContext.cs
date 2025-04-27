using Day01_API.Configure;
using Microsoft.EntityFrameworkCore;

namespace Day01_API.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext() : base()
		{

		}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new CourseConfiguration());
		}
		public DbSet<Course> Courses { get; set; }
	}
}

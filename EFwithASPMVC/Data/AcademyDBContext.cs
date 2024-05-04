using Application.Models.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Application.Data
{
	public class AcademyDBContext : DbContext
	{
		public AcademyDBContext(DbContextOptions options)
			: base(options)
		{ }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>()
				.HasOne(s => s.Group)
				.WithMany(s => s.Students)
				.HasForeignKey(s => s.GroupId);
		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Group> Groups { get; set; }


	}
}

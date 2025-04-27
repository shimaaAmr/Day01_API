using Day01_API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Day01_API.Configure
{
	public class CourseConfiguration : IEntityTypeConfiguration<Course>
	{
		void IEntityTypeConfiguration<Course>.Configure(EntityTypeBuilder<Course> builder)
		{
			builder.HasKey(c => c.Id);

			builder.Property(c => c.Name)
				.HasMaxLength(50)
				.IsUnicode(true)
				.IsRequired(false);

			builder.Property(c => c.Description)
				.HasMaxLength(150)
				.IsUnicode(true)
				.IsRequired(false);

			builder.Property(c => c.Duration)
				.IsRequired(false);

		}
	}
}

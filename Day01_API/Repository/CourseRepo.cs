using Day01_API.IRepository;
using Day01_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Day01_API.Repository
{
	public class CourseRepo : ICourseRepo
	{
		readonly AppDbContext _context;
		public CourseRepo(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Course>?> DeleteCourseAsync(int id)
		{
			var result = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
			if (result != null)
			{
				_context.Courses.Remove(result);
				return await _context.Courses.ToListAsync();

			}
			return null;
		}

		public async Task<List<Course>> GetAllAsync()
		{
			return await _context.Courses.ToListAsync();
		}

		public async Task<Course?> GetByIdAsync(int id)
		{
			return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<Course?> GetByNameAsync(string name)
		{
			return await _context.Courses.FirstOrDefaultAsync(c => c.Name == name);
		}

		public async Task AddAsync(Course course)
		{
			await _context.Courses.AddAsync(course);
			await _context.SaveChangesAsync();
		}

		public async Task PutAsync(int id, Course courseFromReq)
		{
			var result = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
			if (result != null)
			{
				result.Name = courseFromReq.Name;
				result.Duration = courseFromReq.Duration;
				result.Description = courseFromReq.Description;
			}
			_context.Courses.Update(result);
			_context.SaveChangesAsync();
		}




	}
}

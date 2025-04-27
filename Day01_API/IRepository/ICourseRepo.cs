using Day01_API.Models;

namespace Day01_API.IRepository
{
	public interface ICourseRepo
	{
		Task<List<Course>> GetAllAsync();
		Task<List<Course>?> DeleteCourseAsync(int id);
		Task PutAsync(int id, Course course);
		Task AddAsync(Course course);
		Task<Course?> GetByIdAsync(int id);
		Task<Course?> GetByNameAsync(string name);
	}
}

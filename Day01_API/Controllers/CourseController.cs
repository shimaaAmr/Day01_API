using Day01_API.IRepository;
using Day01_API.Models;
using Day01_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Day01_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		readonly ICourseRepo _repo;
		readonly Course _course;

		public CourseController(ICourseRepo repo)
		{
			_repo = repo;
		}

		[HttpPost]
		public async Task<IActionResult> Post(Course course)
		{
			if (course == null)
			{
				return BadRequest("Course data is required.");//404
			}

			await _repo.AddAsync(course);
			return CreatedAtAction(nameof(Get), new { id = course.Id }, course);//201
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetById(int id)
		{

			var course = await _repo.GetByIdAsync(id);
			if (course != null)
			{
				return Ok(course); // 200 return course
			}
			return BadRequest("Course Not found");

		}

		[HttpGet("{name:alpha}")]
		public async Task<IActionResult> GetByName(string name)
		{

			var course = await _repo.GetByNameAsync(name);
			if (course != null)
			{
				return Ok(course); // 200 return course
			}
			return BadRequest("Course Not found");

		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var courses = await _repo.GetAllAsync();
			if (courses != null)
			{
				return Ok(courses);
			}
			return BadRequest("Not Found Courses");
		}
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, Course course)
		{

			if (id != course.Id)
			{
				return BadRequest("Course ID in the URL does not match the ID in the body.");
			}
			var existingCourse = await _repo.GetByIdAsync(id);

			if (existingCourse == null)
			{
				return NotFound("Course not found.");
			}
			_repo.PutAsync(id, course);
			return NoContent();
		}

	}
}

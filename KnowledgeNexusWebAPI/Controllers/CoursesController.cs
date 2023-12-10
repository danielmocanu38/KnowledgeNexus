using KnowledgeNexusModels.Models;
using KnowledgeNexusWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeNexusWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
	private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
		_courseService = courseService;
    }

	[HttpPost]
	public async Task<IActionResult> CreateAnnouncement([FromBody] Course course)
	{

		if (course == null)
		{
			return BadRequest("Announcement cannot be null");
		}
		var isCreated = await _courseService.Create(course);
		if (!(isCreated))
		{
			return BadRequest("Something went wrong");
		}
		return Ok(course);
		//return CreatedAtAction(nameof(GetAnnouncementById), new { id = announcement.Id }, announcement);
	}

	[HttpGet]
	public async Task<IActionResult> GetCourses()
	{
		return Ok(await _courseService.GetAll());
	}


	[HttpGet("getById/{id}")]
	public async Task<IActionResult> GetAnnouncementById(string id)
	{
		var announcement = await _courseService.Get(id);

		if (announcement == null)
		{
			return NotFound();
		}

		return Ok(announcement);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateCourse(string id, [FromBody] Course course)
	{
		if (course == null || id != course.Id)
		{
			return BadRequest("Invalid course or ID mismatch");
		}

		var existingCourse = await _courseService.Get(id);

		if (existingCourse == null)
		{
			return NotFound("Course not found");
		}

		var updated = await _courseService.Update(id, course);

		if (!updated)
		{
			return BadRequest("Something went wrong while updating");
		}

		return Ok(course);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCourse(string id)
	{
		var existingCourse = await _courseService.Get(id);

		if (existingCourse == null)
		{
			return NotFound("Course not found");
		}

		var deleted = await _courseService.Delete(id);

		if (!deleted)
		{
			return BadRequest("Something went wrong while deleting");
		}

		return Ok("Course deleted successfully");
	}

}

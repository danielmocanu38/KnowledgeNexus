using KnowledgeNexusModels.Models;
using KnowledgeNexusWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace KnowledgeNexusWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
	ICourseService _courseService;
    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService ?? throw new ArgumentNullException(nameof(CourseService));
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


}

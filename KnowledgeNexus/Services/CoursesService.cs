using KnowledgeNexusModels.Models;
using MongoDB.Bson;

namespace KnowledgeNexus.Services;

public class CoursesService
{
	private readonly HttpClient _httpClient;

	public CoursesService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<Course>?> GetAllCoursesAsync()
	{
		return await _httpClient.GetFromJsonAsync<List<Course>>("api/Courses");
	}

	public async Task<Course?> GetCourseByIdAsync(string id)
	{
		return await _httpClient.GetFromJsonAsync<Course>($"api/Courses/getById/{id}");
	}
}

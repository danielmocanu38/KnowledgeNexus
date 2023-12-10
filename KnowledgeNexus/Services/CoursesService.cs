using KnowledgeNexusModels.Models;
using System.Text.Json;
using System.Text;

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

	public async Task<bool> CreateCourseAsync(Course course)
	{
		var content = new StringContent(JsonSerializer.Serialize(course), Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync("api/Courses", content);

		return response.IsSuccessStatusCode;
	}

	public async Task<bool> UpdateCourseAsync(string id, Course course)
	{
		var content = new StringContent(JsonSerializer.Serialize(course), Encoding.UTF8, "application/json");
		var response = await _httpClient.PutAsync($"api/Courses/{id}", content);

		return response.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteCourseAsync(string id)
	{
		var response = await _httpClient.DeleteAsync($"api/Courses/{id}");

		return response.IsSuccessStatusCode;
	}
}

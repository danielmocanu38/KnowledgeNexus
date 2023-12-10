using KnowledgeNexusModels.Models;
using KnowledgeNexusWebAPI.Settings;
using MongoDB.Driver;

namespace KnowledgeNexusWebAPI.Services;

public class CourseService : ICourseService
{
	private readonly IMongoCollection<Course> _courses;

	public CourseService(IMongoDbSettings mongoDbSettings)
	{
		var client = new MongoClient(mongoDbSettings.ConnectionString);
		var database = client.GetDatabase(mongoDbSettings.DatabaseName);
		_courses = database.GetCollection<Course>(mongoDbSettings.CollectionName);
	}

	public async Task<bool> Create(Course model)
	{
		await _courses.InsertOneAsync(model);
		return true;
	}

	public async Task<bool> Delete(string id)
	{
		await _courses.DeleteOneAsync(course => course.Id == id);
		return true;
	}

	public async Task<Course> Get(string id)
	{
		return await _courses.Find(course => course.Id == id).FirstOrDefaultAsync();
	}

	public async Task<List<Course>> GetAll()
	{
		return await _courses.Find(course => true).ToListAsync();
	}

	public async Task<bool> Update(string id, Course model)
	{
		await _courses.ReplaceOneAsync(course => course.Id == id, model);
		return true;
	}
}

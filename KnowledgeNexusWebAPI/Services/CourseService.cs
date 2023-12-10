using KnowledgeNexusModels.Models;
using KnowledgeNexusWebAPI.Settings;
using MongoDB.Bson;
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

	public Task<bool> Delete(string id)
	{
		throw new NotImplementedException();
	}

	public async Task<Course> Get(string id)
	{
		return (await _courses.FindAsync(course => course.Id == id)).FirstOrDefault();
	}

	public async Task<List<Course>> GetAll()
	{
		var result = await _courses.FindAsync(course => true);
		return result.ToList();
	}

	public Task<bool> Update(string id, Course model)
	{
		throw new NotImplementedException();
	}
}

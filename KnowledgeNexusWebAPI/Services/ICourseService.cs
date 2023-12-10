using KnowledgeNexusModels.Models;

namespace KnowledgeNexusWebAPI.Services;

public interface ICourseService : ICollectionService<Course>
{
	Task<List<Course>> GetByText(string text);
}

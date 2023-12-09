using MongoDB.Bson;

namespace KnowledgeNexusModels.Models
{
    public class Course
    {
        public ObjectId Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
    }
}

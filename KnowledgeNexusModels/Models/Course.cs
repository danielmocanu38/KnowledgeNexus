using MongoDB.Bson;

namespace KnowledgeNexusModels.Models
{
    public class Course
    {
        public ObjectId Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}

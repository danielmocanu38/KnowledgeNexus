using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KnowledgeNexusModels.Models
{
	public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
		public string? Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = [];
        public List<CourseContent> Contents { get; set; } = [];
    }

    public class CourseContent
    {
        public ContentType Type { get; set; }
        public string Url { get; set; } = string.Empty;
    }

    public enum ContentType
    {
        Audio,
        Video,
        PDF,
    }
}

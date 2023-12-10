using System.Collections.Generic;
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
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<CourseContent> Contents { get; set; } = new List<CourseContent>();
    }

    public class Category
    {
        public string Name { get; set; } = string.Empty;
        public string ParentCategory { get; set; } = string.Empty; // Parent category name
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

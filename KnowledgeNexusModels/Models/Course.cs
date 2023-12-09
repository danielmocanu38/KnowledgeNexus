using System.Collections.Generic;
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
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<CourseContent> Contents { get; set; } = new List<CourseContent>();
    }

    public class Category
    {
        public string Name { get; set; }
        public string ParentCategory { get; set; } // Parent category name
    }

    public class CourseContent
    {
        public ContentType Type { get; set; }
        public string Url { get; set; }
    }

    public enum ContentType
    {
        Audio,
        Video,
        PDF,
    }
}

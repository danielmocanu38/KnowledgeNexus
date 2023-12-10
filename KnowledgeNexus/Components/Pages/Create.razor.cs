using KnowledgeNexus.Services;
using KnowledgeNexusModels.Models;

namespace KnowledgeNexus.Components.Pages
{
	public partial class Create
	{
		private Course _course = new();
		private string _selectedContentType = "Audio";
		private string _contentUrl = string.Empty;
		public required string Tag { get; set; }

		private async Task CreateCourse()
		{
			// Call service to save course data in the database
			await CoursesService.CreateCourseAsync(_course);
		}

		private void AddTag()
		{
			if (!string.IsNullOrWhiteSpace(Tag))
			{
				_course.Categories.Add(Tag);
				Tag = string.Empty;
			}
		}

		private void AddContent()
		{
			if (!string.IsNullOrWhiteSpace(_contentUrl))
			{
				if (Enum.TryParse(_selectedContentType, out ContentType type)) ;
				{
					_course.Contents.Add(new CourseContent
					{
						Type = type,
						Url = _contentUrl
					});

					// Clear the input fields after adding content
					_contentUrl = string.Empty;
				}
			}
		}
	}
}
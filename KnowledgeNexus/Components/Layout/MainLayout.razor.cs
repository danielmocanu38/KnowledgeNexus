using KnowledgeNexus.Components.Pages;
using KnowledgeNexus.Services;

namespace KnowledgeNexus.Components.Layout;

public partial class MainLayout
{
	private string searchTerm = string.Empty;

	private void SearchCourses()
	{
		Home.courses = CoursesService.GetCourseByText(searchTerm).Result;
	}
}
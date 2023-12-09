namespace KnowledgeNexus.Components.Pages;

public partial class Home
{
    string searchTerm = string.Empty;

    private readonly Dictionary<string, List<string>> filters = new()
    {
        { "Subject", new List<string> { "Math", "Science", "Literature" } },
        { "Partner", new List<string> { "University A", "Company B", "Institution C" } },
        // Add other filters as needed
    };

    private readonly Dictionary<string, string> selectedFilters = [];

    static void SearchCourses()
    {
        // Logic to search courses based on searchTerm and any filters
    }

    private void SetFilter(string filterKey, string? selectedOption)
    {
        if (selectedOption == null)
        {
            return;
        }

        if (!selectedFilters.TryAdd(filterKey, selectedOption))
        {
            selectedFilters[filterKey] = selectedOption;
        }

        // Here, you could also call a method to update the course list based on the new filters
    }
}

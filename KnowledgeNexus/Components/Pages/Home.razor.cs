namespace KnowledgeNexus.Components.Pages;

public partial class Home
{
    string searchTerm = string.Empty;

    private readonly Dictionary<string, List<string>> filters = new()
    {
        { "Subject", new List<string> { "Math", "Science", "Literature" } },
        {"Language", new List<string> {"En", "Ro"} },
        {"Content", new List<string> {"Audio, Video, Text"} },
        { "Source", new List<string> { "University A" } },
        // Add other filters as needed
    };

    private readonly Dictionary<string, string> selectedFilters = [];

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

using CollectionPR.Models;

namespace CollectionPR.ViewModels;

public class SearchViewModel
{
    public List<Item> resultItems { get; set; } = new List<Item>();

    public string? Text { get; set; }
}
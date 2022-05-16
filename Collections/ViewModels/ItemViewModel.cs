using System.ComponentModel.DataAnnotations;

namespace CollectionPR.ViewModels;

public class ItemViewModel
{
    [Required]
    public int CollectionId { get; set; }

    [Required]
    public string? Title { get; init; }
         
    [Required]
    public string? Description { get; init; }

    public string? Date { get; init; }
    public string? Brand { get; init; }
}
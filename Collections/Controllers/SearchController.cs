using CollectionPR.Data.Interfaces;
using CollectionPR.Models;
using CollectionPR.Services.Interfaces;
using CollectionPR.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CollectionPR.Controllers;

public class SearchController : Controller
{
    private readonly IItemService itemService;
    public SearchController(IItemService itemService)
    {
        this.itemService = itemService;
    }
    
    [Route("/Home/Search/")]
    public async Task<IActionResult> SearchResultViewEmpty(string searchString, SearchViewModel searchViewModel)
    {
        searchViewModel.resultItems = new List<Item>();

        return await Task.Run(() => View("Search", searchViewModel));
    }
    
    [Route("/Home/Search/{searchString}")]
    public async Task<IActionResult> SearchResultView(string searchString, SearchViewModel searchViewModel)
    {
        searchViewModel.resultItems = itemService.FullTextSearch(searchString);
        
        return await Task.Run(() => View("Search", searchViewModel));
    }
}
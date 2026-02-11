using Microsoft.Playwright;
namespace SauceDemoTests.Pages;

public class ProductsPage(IPage page)
{
    private readonly IPage _page = page;
    private readonly string TitleLocator = ".title";

    

    public async Task<string> GetTitleText()
    {
        LoginPage loginPage = new LoginPage(_page);
        var title = _page.Locator(TitleLocator);
        return await title.InnerTextAsync();
    }  

    public async Task<int> GetInventoryItemsCount()
    {
        var inventoryItems = _page.Locator(".inventory_item");
        return await inventoryItems.CountAsync();
    } 

}
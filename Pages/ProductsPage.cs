using Microsoft.Playwright;

namespace SauceDemoTests.Pages;

public class ProductsPage
{
    private readonly IPage _page;
    private readonly ILocator TitleLocator;
    private readonly ILocator ShoppingCartLink;

    public ProductsPage(IPage page)
    {
        _page = page;
        TitleLocator = _page.Locator(".title");
        ShoppingCartLink = _page.Locator(".shopping_cart_link");
    }

    public async Task<string> GetTitleText()
    {
        LoginPage loginPage = new LoginPage(_page);
        var title =TitleLocator.First;
        return await title.InnerTextAsync();
    }  

    public async Task<int> GetInventoryItemsCount()
    {
        var inventoryItems = _page.Locator(".inventory_item");
        return await inventoryItems.CountAsync();
    }

     public async Task ClickShoppingCartIcon()
    {
        var shoppingCartIcon = ShoppingCartLink;
        await shoppingCartIcon.ClickAsync();
    }
}
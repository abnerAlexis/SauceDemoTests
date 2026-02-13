using Microsoft.Playwright;

namespace SauceDemoTests.Pages;

public class ShoppingCartPage
{
    private readonly IPage _page;
    private readonly ILocator TitleLocator;

    public ShoppingCartPage(IPage page)
    {
        _page = page;
        TitleLocator = _page.Locator(".title");
    }

    public async Task<string> GetTitleText()
    {
        var title = TitleLocator.InnerTextAsync();
        return await title;
    }
}
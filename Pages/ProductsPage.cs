using Microsoft.Playwright;
using LoginPage = SauceDemoTests.Pages.LoginPage;
namespace SauceDemoTests.Pages;

public class ProductsPage(IPage page)
{
    private readonly IPage _page = page;
    private readonly string TitleLocator = ".title";

    public async Task<string> GetTitleText()
    {
        LoginPage loginPage = new LoginPage(_page);
        await loginPage.Login("standard_user", "secret_sauce");
        var title = _page.Locator(TitleLocator);
        return await title.InnerTextAsync();
    }   

}


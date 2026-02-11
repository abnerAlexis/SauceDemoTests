using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SauceDemoTests.Pages;
namespace SauceDemoTests.Tests;

public class ProductsPageTests : PageTest
{
    [Test]
    public async Task VerifyProductsPageTitle()
    {
        await Page.GotoAsync(Config.BaseUrl);
        var loginPage = new LoginPage(Page);
        var productsPage = await loginPage.Login(Config.StandardUser, Config.Password);
        await Page.WaitForURLAsync("**/inventory.html");
        var page = new ProductsPage(Page);
        var titleText = await page.GetTitleText();
        Assert.That(titleText, Is.EqualTo("Products"));
    }

    [Test]
    public async Task VerifyShoppingCartIconIsVisible()
    {
        await Page.GotoAsync(Config.BaseUrl);
        var loginPage = new LoginPage(Page);
        var productsPage = await loginPage.Login(Config.StandardUser, Config.Password);
        await Page.WaitForURLAsync("**/inventory.html");
        var shoppingCartIcon = Page.Locator(".shopping_cart_link");
        await Expect(shoppingCartIcon).ToBeVisibleAsync();
    }
}
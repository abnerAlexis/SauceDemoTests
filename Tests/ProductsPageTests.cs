using Microsoft.Playwright.NUnit;
using SauceDemoTests.Pages;
namespace SauceDemoTests.Tests;

public class ProductsPageTests : PageTest
{
    [Test]
    public async Task VerifyProductsPageTitle()
    {
        await Page.GotoAsync(Config.BaseUrl);
        var loginPage = new LoginPage(Page);
        await loginPage.Login(Config.StandardUser, Config.Password);
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
        await loginPage.Login(Config.StandardUser, Config.Password);
        await Page.WaitForURLAsync("**/inventory.html");
        var shoppingCartIcon = Page.Locator(".shopping_cart_link");
        await Expect(shoppingCartIcon).ToBeVisibleAsync();
    }

    [Test]
    public async Task VerifyItemsAreDisplayed()
    {
        await Page.GotoAsync(Config.BaseUrl);
        var loginPage = new LoginPage(Page);
        await loginPage.Login(Config.StandardUser, Config.Password);
        await Page.WaitForURLAsync("**/inventory.html");
        var productsPage = new ProductsPage(Page);
        await productsPage.GetInventoryItemsCount();
        int ItemCount = await productsPage.GetInventoryItemsCount();
        Assert.That(ItemCount, Is.GreaterThan(0), "No items were found on the products page.");
    }

    [Test]
    public async Task ClickShoppingCartIconTest()
    {
        await Page.GotoAsync(Config.BaseUrl);
        var loginPage = new LoginPage(Page);
        await loginPage.Login(Config.StandardUser, Config.Password);
        await Page.WaitForURLAsync("**/inventory.html");
        var productsPage = new ProductsPage(Page);
        await productsPage.ClickShoppingCartIcon();
        await Page.WaitForURLAsync(Config.BaseUrl + "cart.html");
        await Expect(Page).ToHaveURLAsync(Config.BaseUrl + "cart.html");
    }
}
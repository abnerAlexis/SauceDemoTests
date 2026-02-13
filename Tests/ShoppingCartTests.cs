using System.Diagnostics;
using Microsoft.Playwright.NUnit;
using SauceDemoTests.Pages;
namespace SauceDemoTests.Tests;

public class ShoppingCartTests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync(Config.BaseUrl);
        var loginPage = new LoginPage(Page);
        await loginPage.Login(Config.StandardUser, Config.Password);
        await Page.WaitForURLAsync("**/inventory.html");
        var productsPage = new ProductsPage(Page);
        await productsPage.ClickShoppingCartIcon();
        await Page.WaitForURLAsync(Config.BaseUrl + "cart.html");
    }

    [Test]
    public async Task VerifyShoppingCartPageTitle()
    {
        var shoppingCartPage = new ShoppingCartPage(Page);
        var titleText = await shoppingCartPage.GetTitleText();
        Assert.That(titleText, Is.EqualTo("Your Cart"));
    }
}
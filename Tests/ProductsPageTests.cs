using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using SauceDemoTests.Pages;
namespace SauceDemoTests.Tests;

public class ProductsPageTests : PageTest
{
    [Test]
    public async Task VerifyProductsPageTitle()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
        var loginPage = new LoginPage(Page);
        var productsPage = await loginPage.Login("standard_user", "secret_sauce");
        await Page.WaitForURLAsync("**/inventory.html");
        var page = new ProductsPage(Page);
        var titleText = await page.GetTitleText();
        Assert.That(titleText, Is.EqualTo("Products"));
    }
}
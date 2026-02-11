using Microsoft.Playwright.NUnit;
using Microsoft.VisualBasic;
using SauceDemoTests.Pages;

namespace SauceDemoTests.Tests;

public class LoginTests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        var page = new LoginPage(Page);
        await page.GoToLoginPage();
        await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/");
    }

    [Test]
    public async Task SuccessfulLoginTest()
    {
        var page = new LoginPage(Page);
        await page.SuccessfulLogin();
        await Page.WaitForURLAsync("**/inventory.html");

        var title = Page.Locator(".title");
        await Expect(title).ToHaveTextAsync("Products");

        await Page.PauseAsync();
        // Assert.Pass();

    }
}

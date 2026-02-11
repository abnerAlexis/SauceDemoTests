using Microsoft.Playwright.NUnit;
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
        await page.Login("standard_user", "secret_sauce");
        await Page.WaitForURLAsync("**/inventory.html");

        var title = Page.Locator(".title");
        await Expect(title).ToHaveTextAsync("Products");
    
        // await Page.PauseAsync();
        // Assert.Pass();
    }

    [Test]
    public async Task LockedOutUserLoginTest()
    {
        var page = new LoginPage(Page);    
        await page.Login("locked_out_user", "secret_sauce");
        var errorMessage = Page.Locator("[data-test=\'error\']");
        await Expect(errorMessage).ToHaveTextAsync("Epic sadface: Sorry, this user has been locked out.");
        // await Page.PauseAsync();
    }
}

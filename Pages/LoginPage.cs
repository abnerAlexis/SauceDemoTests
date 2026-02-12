using Microsoft.Playwright;

namespace SauceDemoTests.Pages;

public class LoginPage
{
    private readonly IPage _page;
    private readonly ILocator UsernameLocator;
    private readonly ILocator PasswordLocator;
    private readonly ILocator LoginBtnLocator;


    public LoginPage(IPage page)
    {
        _page = page;
        UsernameLocator = _page.Locator("#user-name");
        PasswordLocator = _page.Locator("#password");
        LoginBtnLocator = _page.Locator("#login-button");
    }

        public async Task GoToLoginPage()
        {
            await _page.GotoAsync(Config.BaseUrl);
        }   
        public async Task Login(string username, string password)
        {
            await UsernameLocator.FillAsync(username);
            await PasswordLocator.FillAsync(password);
            await LoginBtnLocator.ClickAsync();
        }
    }
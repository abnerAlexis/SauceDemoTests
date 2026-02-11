using Microsoft.Playwright;

namespace SauceDemoTests.Pages;

public class LoginPage(IPage page)
{
    private readonly IPage _page = page;
    private readonly string URL = "https://www.saucedemo.com/";
    private readonly string UsernameLocator = "#user-name";
    private readonly string PasswordLocator = "#password"; 
    private readonly string LoginBtnLocator = "#login-button";


        public async Task GoToLoginPage()
        {
            await _page.GotoAsync(URL);
        }   
        public async Task<ProductsPage> Login(string username, string password)
        {
            await _page.FillAsync(UsernameLocator, username);
            await _page.FillAsync(PasswordLocator, password);
            await _page.ClickAsync(LoginBtnLocator);     
            return new ProductsPage(_page);     
        }

    }
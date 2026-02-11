using Microsoft.Playwright;

namespace SauceDemoTests.Pages;

public class LoginPage(IPage page)
{
    private readonly IPage _page = page;
    private readonly string URL = "https://www.saucedemo.com/";
    private readonly string StandardUser = "standard_user";
    private readonly string StdUserLocator = "#user-name";
    // private readonly string LockedOutUser = "locked_out_user";
    // private readonly string ProblemUser = "problem_user";
    // private readonly string PerfomanceGlitchUser = "performance_glitch_user";
    // private readonly string ErrorUser = "error_user";
    // private readonly string VisualUser = "visual_user";
    private readonly string Password = "secret_sauce";
    private readonly string PW = "#password";
    private readonly string LoginBtn = "#login-button";


        public async Task GoToLoginPage()
        {
            await _page.GotoAsync(URL);
        }   
        public async Task SuccessfulLogin()
        {
           await _page.FillAsync(StdUserLocator, StandardUser);
           await _page.FillAsync(PW, Password);
           await _page.ClickAsync(LoginBtn);
        }

    }
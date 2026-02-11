using DotNetEnv;
namespace SauceDemoTests;

public static class Config
{
    static Config() => Env.Load(); // automatically load .env

    public static string StandardUser => Env.GetString("STANDARD_USER");
    public static string LockedUser => Env.GetString("LOCKED_USER");
    public static string Password => Env.GetString("PASSWORD");
    public static string BaseUrl => Env.GetString("BASE_URL");  
}
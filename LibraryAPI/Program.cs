using LibraryAPI.Data;

namespace LibraryAPI
{
    public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        startup.Configure(app, app.Environment);
        startup.InitializeDatabase(app.Services.GetService<AppDBContext>());
        app.Run();
    }
}
}
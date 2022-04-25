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
#if RELEASE
            startup.InitializeDatabase(app.Services.GetService<Data.AppDBContext>());
#endif
            app.Run();
        }
    }
}
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using LibraryAPI.Data;
using LibraryAPI.MapperProfiles;
using LibraryAPI.Services;
using LiteDB;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAppDBContext>(provider => provider.GetService<AppDBContext>());

            services.AddScoped<ILiteDatabase>(_ => new LiteDatabase(_configuration.GetConnectionString("NoSQLConnection")));
            services.AddScoped<IDataStorageService<Guid>, DataStorageService>();
            services.AddScoped<IUserService, UserService>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(MenuMapperProfile));

            services.AddHostedService<Library.MenuBot.BotService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureConfiguration(IConfigurationBuilder configuration)
        {
            configuration.AddJsonFile("bottokens.json");
        }

        public void InitializeDatabase(AppDBContext ctx)
        {
            ctx.Database.Migrate();
        }
    }
}
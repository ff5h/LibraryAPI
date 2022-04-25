using LibraryAPI.Data;
using LibraryAPI.MapperProfiles;
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
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(Startup));
            services.AddAutoMapper(typeof(BookMapperProfile),
                                   typeof(ClientMapperProfile));
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

        public void InitializeDatabase(AppDBContext ctx)
        {
            ctx.Database.Migrate();
        }
    }
}
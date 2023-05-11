using NG_2023_Kanban.Service;
using Microsoft.EntityFrameworkCore;

namespace NG_2023_Kanban.DbStartup
{
    public static class Injecting
    {
        public static void Inject(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(
                    configuration["ConnectionString"]);
            });
            services.AddScoped<DbService>();
        }
    }
}

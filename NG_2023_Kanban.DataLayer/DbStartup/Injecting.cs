using NG_2023_Kanban.DataLayer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NG_2023_Kanban.DataLayer.DbStartup
{
    public static class Injecting
    {
        public static void InjectDAL(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(
                    configuration["ConnectionString"]);
            });
            services.AddScoped<DataService>();
        }
    }
}

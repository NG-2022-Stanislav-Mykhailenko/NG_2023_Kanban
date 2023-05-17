using NG_2023_Kanban.DataLayer.Repositories;
﻿using NG_2023_Kanban.DataLayer.Interfaces;
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
            services.AddTransient<IBoardRepository, BoardRepository>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<IColumnRepository, ColumnRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            optionsBuilder.UseSqlServer(configuration["ConnectionString"]);

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(
                    configuration["ConnectionString"]);
            });

            (new DatabaseContext(optionsBuilder.Options)).Database.EnsureCreated(); // possibly misplaced
        }
    }
}

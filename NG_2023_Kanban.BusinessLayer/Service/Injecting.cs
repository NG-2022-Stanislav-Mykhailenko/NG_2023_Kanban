﻿using NG_2023_Kanban.BusinessLayer.Service;
using Microsoft.Extensions.DependencyInjection;

namespace NG_2023_Kanban.BusinessLayer.Inject
{
    public static class Injecting
    {
        public static void InjectBLL(
            this IServiceCollection services)
        {
            services.AddScoped<BusinessService>();
        }
    }
}

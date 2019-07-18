using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnkeiSolutionLib.Service;

namespace OnkeiSolutionLib
{
    public static class RootConfig
    {
        public static void Entry(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(INMapService), typeof(NMapService));
            services.AddScoped(typeof(ISqlMapService), typeof(SqlMapService));
        }
    }
}

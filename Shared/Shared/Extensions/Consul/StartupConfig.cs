﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Shared.Extensions.Consul
{
    [ExcludeFromCodeCoverage]
    public static class StartupConfig
    {
        public static ConfigurationSetting RegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConfigurationSetting>(configuration.GetSection("Configuration"));
            var serviceProvider = services.BuildServiceProvider();
            var iop = serviceProvider.GetService<IOptions<ConfigurationSetting>>();
            return iop.Value;
        }
    }
}

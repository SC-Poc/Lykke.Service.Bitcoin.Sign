using System;
using JetBrains.Annotations;
using Lykke.Sdk;
using Lykke.Service.Bitcoin.Sign.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Lykke.Service.Bitcoin.Sign
{
    [UsedImplicitly]
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var service = services.BuildServiceProvider<AppSettings>(options =>
            {
                options.Logs = logs => logs.UseEmptyLogging();

                options.Swagger = swagger =>
                {
                    swagger.DescribeAllEnumsAsStrings();
                    swagger.DescribeStringEnumsInCamelCase();
                };

                options.SwaggerOptions = new LykkeSwaggerOptions
                {
                    ApiTitle = "Bitcoin.Sign"
                };
            });

            return service;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseLykkeConfiguration();
        }
    }
}

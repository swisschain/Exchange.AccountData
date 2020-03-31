using System.Reflection;
using Microsoft.Extensions.Configuration;
using AccountData.Common.Configuration;
using Autofac;
using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swisschain.Sdk.Server.Common;

namespace AccountData
{
    public sealed class Startup : SwisschainStartup<AppConfig>
    {
        public Startup(IConfiguration configuration)
            : base(configuration)
        {
            AddJwtAuth(Config.Jwt.Secret, "exchange.swisschain.io");
        }

        protected override void ConfigureServicesExt(IServiceCollection services)
        {
            services
                .AddAutoMapper(typeof(AutoMapperProfile), typeof(Common.Services.AutoMapperProfile))
                .AddControllersWithViews()
                .AddFluentValidation(options =>
                {
                    ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
                    options.RegisterValidatorsFromAssembly(Assembly.GetEntryAssembly());
                });
        }

        protected override void ConfigureExt(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthorization();

            app.ApplicationServices.GetRequiredService<AutoMapper.IConfigurationProvider>()
                .AssertConfigurationIsValid();
        }

        protected override void ConfigureContainerExt(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutofacModule(Config.AccountDataService.BalancesServiceAddress));
            builder.RegisterModule(new Common.Services.AutofacModule());
        }
    }
}

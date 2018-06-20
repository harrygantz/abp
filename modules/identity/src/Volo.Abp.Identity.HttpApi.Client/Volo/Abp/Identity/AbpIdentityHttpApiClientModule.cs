﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.Users;

namespace Volo.Abp.Identity
{
    [DependsOn(
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpUsersAbstractionModule),
        typeof(AbpHttpClientModule))]
    public class AbpIdentityHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "AbpIdentity";

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClientProxies(typeof(AbpIdentityApplicationContractsModule).Assembly, RemoteServiceName);

            services.AddAssemblyOf<AbpIdentityHttpApiClientModule>();
        }
    }
}
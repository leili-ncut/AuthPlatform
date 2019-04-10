using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Dapper.HostedServices;
using IdentityServer4.Dapper.Interfaces;
using IdentityServer4.Dapper.Options;
using IdentityServer4.Dapper.Stores.SqlServer;
using IdentityServer4.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IdentityServer4.Dapper.Extensions
{
    /// <summary>
    /// 使用Dapper扩展
    /// </summary>
    public static class IdentityServerDapperBuilderExtensions
    {
        public static IIdentityServerBuilder AddDapperStore(
            this IIdentityServerBuilder builder,
            Action<DapperStoreOptions> storeOptionsAction)
        {
            var options = new DapperStoreOptions();
            builder.Services.AddSingleton(options);
            storeOptionsAction?.Invoke(options);
            builder.Services.AddTransient<IClientStore, SqlServerClientStore>();
            builder.Services.AddTransient<IResourceStore, SqlServerResourceStore>();
            builder.Services.AddTransient<IPersistedGrantStore, SqlServerPersistedGrantStore>();
            builder.Services.AddTransient<IPersistedGrants, SqlServerPersistedGrants>();
            builder.Services.AddSingleton<TokenCleanup>();
            builder.Services.AddSingleton<IHostedService, TokenCleanupHost>();
            return builder;
        }
    }
}

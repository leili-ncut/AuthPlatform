using System;
using System.Collections.Generic;
using System.Text;
using Lil.AuthPlatform.AhphOcelot.Authentication;
using Lil.AuthPlatform.AhphOcelot.Cache;
using Lil.AuthPlatform.AhphOcelot.Configuration;
using Lil.AuthPlatform.AhphOcelot.DataBase.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Ocelot.Cache;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.DependencyInjection;

namespace Lil.AuthPlatform.AhphOcelot.Middleware
{
    /// <summary>
    ///  扩展Ocelot实现的自定义的注入
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IOcelotBuilder AddAhphOcelot(this IOcelotBuilder builder, Action<AhphOcelotConfiguration> action)
        {
            builder.Services.Configure(action);
            //配置信息
            builder.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<AhphOcelotConfiguration>>().Value);
            //文件仓储注入 
            builder.Services.AddSingleton<IFileConfigurationRepository, SqlServerFileConfigurationRepository>();
            builder.Services.AddSingleton<IClientAuthenticationRepository, SqlServerClientAuthenticationRepository>();
            //注册后端服务
            builder.Services.AddHostedService<DbConfigurationPoller>();
            //使用Redis重写缓存
            //builder.Services.AddSingleton(typeof(IOcelotCache<>), typeof(InRedisCache<>));
            builder.Services.AddSingleton<IOcelotCache<FileConfiguration>, InRedisCache<FileConfiguration>>();
            builder.Services.AddSingleton<IOcelotCache<CachedResponse>, InRedisCache<CachedResponse>>();
            builder.Services.AddSingleton<IInternalConfigurationRepository, RedisInternalConfigurationRepository>();
            builder.Services.AddSingleton<IOcelotCache<ClientRoleModel>, InRedisCache<ClientRoleModel>>();
            //注入授权
            builder.Services.AddSingleton<IAhphAuthenticationProcessor, AhphAuthenticationProcessor>();

            return builder;
        }
    }
}

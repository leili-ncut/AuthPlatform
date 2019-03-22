using System;
using System.Collections.Generic;
using System.Text;
using Lil.AuthPlatform.AhphOcelot.Cache;
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
        public static IOcelotBuilder AddAhphOcelot(this IOcelotBuilder builer, Action<AhphOcelotConfiguration> action)
        {
            builer.Services.Configure(action);
            //配置信息
            builer.Services.AddSingleton(
                resolver => resolver.GetRequiredService<IOptions<AhphOcelotConfiguration>>().Value);
            //文件仓储注入 
            builer.Services.AddSingleton<IFileConfigurationRepository, SqlServerFileConfigurationRepository>();
            //注册后端服务
            builer.Services.AddHostedService<DbConfigurationPoller>();
            //使用Redis重写缓存
            //builder.Services.AddSingleton(typeof(IOcelotCache<>), typeof(InRedisCache<>));
            builer.Services.AddSingleton<IOcelotCache<FileConfiguration>, InRedisCache<FileConfiguration>>();
            builer.Services.AddSingleton<IOcelotCache<CachedResponse>, InRedisCache<CachedResponse>>();
            builer.Services.AddSingleton<IInternalConfigurationRepository, RedisInternalConfigurationRepository>();
            return builer;
        }
    }
}

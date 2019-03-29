using System;
using System.Collections.Generic;
using System.Text;
using Ocelot.Middleware.Pipeline;

namespace Lil.AuthPlatform.AhphOcelot.Authentication.Middleware
{
    /// <summary>
    /// 使用自定义授权中间件
    /// </summary>
    public static class AhphAuthenticationMiddlewareExtensions
    {
        public static IOcelotPipelineBuilder UseAhphAuthenticationMiddleware(this IOcelotPipelineBuilder builder)
        {
            return builder.UseMiddleware<AhphAuthenticationMiddleware>();
        }
    }
}

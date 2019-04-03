using System;
using System.Collections.Generic;
using System.Text;
using Lil.AuthPlatform.AhphOcelot.Authentication.Middleware;
using Ocelot.Middleware.Pipeline;

namespace Lil.AuthPlatform.AhphOcelot.RateLimit.Middleware
{
    /// <summary>
    /// 限流中间件扩展
    /// </summary>
    public static class AhphClientRateLimitMiddlewareExtensions
    {
        public static IOcelotPipelineBuilder UseAhphClientRateLimitMiddleware(this IOcelotPipelineBuilder builder)
        {
            return builder.UseMiddleware<AhphClientRateLimitMiddleware>();
        }
    }
}

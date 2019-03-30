using System;
using System.Collections.Generic;
using System.Text;
using Ocelot.Logging;
using Ocelot.Middleware;

namespace Lil.AuthPlatform.AhphOcelot.Authentication.Middleware
{
    /// <summary>
    /// 自定义客户端限流中间件
    /// </summary>
    public class AhphClientRateLimitMiddleware : OcelotMiddleware
    {
        //private readonly 

        public AhphClientRateLimitMiddleware(IOcelotLogger logger) 
            : base(logger)
        {
        }
    }
}

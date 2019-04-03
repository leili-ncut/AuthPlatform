using System;
using System.Collections.Generic;
using System.Text;
using Ocelot.Errors;

namespace Lil.AuthPlatform.AhphOcelot.Errors
{
    /// <summary>
    /// 限流错误信息
    /// </summary>
    public class RateLimitOptionsError : Error
    {
        public RateLimitOptionsError(string message) : base(message, OcelotErrorCode.RateLimitOptionsError)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lil.AuthPlatform.AhphOcelot.Authentication
{
    /// <summary>
    /// 校验当前的请求地址客户端是否有权限访问
    /// </summary>
    /// <param name="clientid">客户端ID</param>
    /// <param name="path">请求地址</param>
    /// <returns></returns>
    public interface IAhphAuthenticationProcessor
    {
        Task<bool> CheckClientAuthenticationAsync(string clientid, string path);
    }
}

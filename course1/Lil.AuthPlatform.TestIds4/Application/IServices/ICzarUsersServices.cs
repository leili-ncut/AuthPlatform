using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.AuthPlatform.TestIds4.Infrastructure;

namespace Lil.AuthPlatform.TestIds4.Application.IServices
{
    /// <summary>
    /// 用户服务接口
    /// </summary>
    public interface ICzarUsersServices
    {
        /// <summary>
        /// 根据账号密码获取用户实体
        /// </summary>
        /// <param name="uaccount">账号</param>
        /// <param name="upassword">密码</param>
        /// <returns></returns>
        CzarUsers FindUserByuAccount(string uaccount, string upassword);

        /// <summary>
        /// 根据用户主键获取用户实体
        /// </summary>
        /// <param name="sub">用户标识</param>
        /// <returns></returns>
        CzarUsers FindUserByUid(string sub);
    }
}

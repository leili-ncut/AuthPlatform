using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lil.AuthPlatform.TestIds4.Application.IRepository;
using Lil.AuthPlatform.TestIds4.Application.IServices;
using Lil.AuthPlatform.TestIds4.Infrastructure;

namespace Lil.AuthPlatform.TestIds4.Application.Services
{
    /// <summary>
    /// 用户服务实现
    /// </summary>
    public class CzarUsersServices : ICzarUsersServices
    {
        private readonly ICzarUsersRepository _czarUsersRepository;
        public CzarUsersServices(ICzarUsersRepository czarUsersRepository)
        {
            _czarUsersRepository = czarUsersRepository;
        }

        /// <summary>
        /// 根据账号密码获取用户实体
        /// </summary>
        /// <param name="uaccount">账号</param>
        /// <param name="upassword">密码</param>
        /// <returns></returns>
        public CzarUsers FindUserByuAccount(string uaccount, string upassword)
        {
            return _czarUsersRepository.FindUserByuAccount(uaccount, upassword);
        }

        /// <summary>
        /// 根据用户主键获取用户实体
        /// </summary>
        /// <param name="sub">用户标识</param>
        /// <returns></returns>
        public CzarUsers FindUserByUid(string sub)
        {
            return _czarUsersRepository.FindUserByUid(sub);
        }
    }
}

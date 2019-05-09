using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Lil.AuthPlatform.TestIds4.Application.IRepository;
using Lil.AuthPlatform.TestIds4.Helpers;
using Lil.AuthPlatform.TestIds4.Infrastructure;
using Lil.AuthPlatform.TestIds4.Infrastructure.Config;
using Microsoft.Extensions.Options;

namespace Lil.AuthPlatform.TestIds4.Application.Repository
{
    /// <summary>
    /// 金焰的世界
    /// 2018-12-18
    /// 用户实体基于SQLSERVER的实现
    /// </summary>
    public class CzarUsersRepository : ICzarUsersRepository
    {
        private readonly string DbConn = "";
        public CzarUsersRepository(IOptions<CzarConfig> czarConfig)
        {
            DbConn = czarConfig.Value.DbConnectionStrings;
        }
        /// <summary>
        /// 根据账号密码获取用户实体
        /// </summary>
        /// <param name="uaccount">账号</param>
        /// <param name="upassword">密码</param>
        /// <returns></returns>
        public CzarUsers FindUserByuAccount(string uaccount, string upassword)
        {
            using (var connection = new SqlConnection(DbConn))
            {
                string sql = @"SELECT * from CzarUsers where uAccount=@uaccount and uPassword=upassword and uStatus=1";
                var result = connection.QueryFirstOrDefault<CzarUsers>(sql, new { uaccount, upassword = SecretHelper.ToMD5(upassword) });
                return result;
            }
        }



        /// <summary>
        /// 根据用户主键获取用户实体
        /// </summary>
        /// <param name="sub">用户标识</param>
        /// <returns></returns>
        public CzarUsers FindUserByUid(string sub)
        {
            using (var connection = new SqlConnection(DbConn))
            {
                string sql = @"SELECT * from CzarUsers where uid=@uid";
                var result = connection.QueryFirstOrDefault<CzarUsers>(sql, new { uid = sub });
                return result;
            }
        }
    }
}

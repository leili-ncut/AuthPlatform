using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IdentityServer4.Dapper.Interfaces;
using IdentityServer4.Dapper.Options;
using Microsoft.Extensions.Logging;

namespace IdentityServer4.Dapper.Stores.SqlServer
{
    /// <summary>
    /// 实现授权信息自定义管理
    /// </summary>
    public class SqlServerPersistedGrants : IPersistedGrants
    {
        private readonly ILogger<SqlServerPersistedGrants> _logger;
        private readonly DapperStoreOptions _configurationStoreOptions;

        public SqlServerPersistedGrants(ILogger<SqlServerPersistedGrants> logger, DapperStoreOptions configurationStoreOptions)
        {
            _logger = logger;
            _configurationStoreOptions = configurationStoreOptions;
        }


        /// <summary>
        /// 移除指定的时间过期授权信息
        /// </summary>
        /// <param name="dt">Utc时间</param>
        /// <returns></returns>
        public async Task RemoveExpireToken(DateTime dt)
        {
            using (var connection = new SqlConnection(_configurationStoreOptions.DbConnectionStrings))
            {
                string sql = "delete from PersistedGrants where Expiration>@dt";
                await connection.ExecuteAsync(sql, new { dt });
            }
        }
    }
}

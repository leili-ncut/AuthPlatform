using System;
using System.Collections.Generic;
using System.Text;
using CSRedis;
using Lil.AuthPlatform.AhphOcelot.Extensions;
using Ocelot.Cache;

namespace Lil.AuthPlatform.AhphOcelot.Cache
{
    /// <summary>
    /// Redis重写缓存
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InRedisCache<T> : IOcelotCache<T>
    {
        private readonly AhphOcelotConfiguration _options;

        public InRedisCache(AhphOcelotConfiguration options)
        {
            _options = options;
            CSRedisClient csRedis;

            if (options.RedisConnectionStrings.Count == 1)
            {
                // 普通模式
                csRedis = new CSRedisClient(options.RedisConnectionStrings[0]);
            }
            else
            {
                // 集群模式
                //实现思路：根据key.GetHashCode() % 节点总数量，确定连向的节点
                //也可以自定义规则(第一个参数设置)
                csRedis = new CSRedis.CSRedisClient(null, options.RedisConnectionStrings.ToArray());
            }

            // Init RedisHelper 
            RedisHelper.Initialization(csRedis);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ttl"></param>
        /// <param name="region"></param>
        public void Add(string key, T value, TimeSpan ttl, string region)
        {
            key = GetKey(region, key);
            if (ttl.TotalMilliseconds <= 0) return;
            RedisHelper.Set(key, value.ToJson(), (int) ttl.TotalSeconds);
        }

        /// <summary>
        /// 获取执行的缓存信息
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="region">缓存分类</param>
        /// <returns></returns>
        public T Get(string key, string region)
        {
            key = GetKey(region, key);
            var result = RedisHelper.Get(key);
            if (!String.IsNullOrEmpty(result))
            {
                return result.ToObject<T>();
            }
            return default(T);
        }

        /// <summary>
        /// 批量移除regin开头的所有缓存记录
        /// </summary>
        /// <param name="region">缓存分类</param>
        public void ClearRegion(string region)
        {
            //获取所有满足条件的key
            var data = RedisHelper.Keys(_options.RedisKeyPrefix + "-" + region + "-*");
            //批量删除
            RedisHelper.Del(data);
        }

        public void AddAndDelete(string key, T value, TimeSpan ttl, string region)
        {
            Add(key, value, ttl, region);
        }

        /// <summary>
        /// 获取格式化后的key
        /// </summary>
        /// <param name="region">分类标识</param>
        /// <param name="key">key</param>
        /// <returns></returns>
        private string GetKey(string region, string key)
        {
            return _options.RedisKeyPrefix + "-" + region + "-" + key;
        }
    }
}

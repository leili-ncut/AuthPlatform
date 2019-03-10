using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Lil.AuthPlatform.AhphOcelot.Extensions
{
    /// <summary>
    /// 自定义扩展实现序列化
    /// </summary>
    public static partial class Ext
    {
        public static T ToObject<T>(this string json)
        {
            return json == null ? default(T) : JsonConvert.DeserializeObject<T>(json);
        }
    }
}

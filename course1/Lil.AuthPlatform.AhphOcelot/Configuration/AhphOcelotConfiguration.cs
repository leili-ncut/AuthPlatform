﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lil.AuthPlatform.AhphOcelot
{
    /// <summary>
    /// 自定义配置信息
    /// </summary>
    public class AhphOcelotConfiguration
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DbConnectionStrings { get; set; }

        /// <summary>
        /// 是否启用定时器，默认不启动
        /// </summary>
        public bool EnableTimer { get; set; } = false;

        /// <summary>
        /// 定时器周期，单位（毫秒），默认30分钟自动更新一次
        /// </summary>
        public int TimerDelay { get; set; } = 1000 * 60 * 30;
    }
}

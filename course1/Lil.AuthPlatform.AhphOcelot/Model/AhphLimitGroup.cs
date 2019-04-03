using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lil.AuthPlatform.AhphOcelot.Model
{
    /// <summary>
    /// 限流组
    /// </summary>
    public partial class AhphLimitGroup
    {
        [Key]
        public int LimitGroupId { get; set; }

        [Required]
        [StringLength(100)]
        public string LimitGroupName { get; set; }

        [StringLength(500)]
        public string LimitGroupDetail { get; set; }

        public int InfoStatus { get; set; }
    }
}

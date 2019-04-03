using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lil.AuthPlatform.AhphOcelot.Model
{
    public partial class AhphLimitGroupRule
    {
        [Key]
        public int GroupRuleId { get; set; }

        public int? LimitGroupId { get; set; }

        public int? ReRouteLimitId { get; set; }
    }
}

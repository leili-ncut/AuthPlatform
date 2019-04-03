using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lil.AuthPlatform.AhphOcelot.Model
{
    public partial class AhphReRouteLimitRule
    {
        [Key]
        public int ReRouteLimitId { get; set; }

        public int? RuleId { get; set; }

        public int? ReRouteId { get; set; }
    }
}

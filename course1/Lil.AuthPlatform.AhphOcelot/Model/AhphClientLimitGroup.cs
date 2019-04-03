using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lil.AuthPlatform.AhphOcelot
{
    public partial class AhphClientLimitGroup
    {
        [Key]
        public int ClientLimitGroupId { get; set; }

        public int? Id { get; set; }

        public int? LimitGroupId { get; set; }
    }
}

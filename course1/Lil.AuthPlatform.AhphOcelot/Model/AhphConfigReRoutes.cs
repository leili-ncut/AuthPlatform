using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lil.AuthPlatform.AhphOcelot.Model
{
    public partial class AhphConfigReRoutes
    {
        [Key]
        public int CtgRouteId { get; set; }

        public int? AhphId { get; set; }

        public int? ReRouteId { get; set; }
    }
}

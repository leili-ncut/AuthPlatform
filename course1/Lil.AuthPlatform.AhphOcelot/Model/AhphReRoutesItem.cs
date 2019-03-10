using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lil.AuthPlatform.AhphOcelot.Model
{
    public partial class AhphReRoutesItem
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        [StringLength(500)]
        public string ItemDetail { get; set; }

        public int? ItemParentId { get; set; }

        public int InfoStatus { get; set; }
    }
}

namespace NhapXuat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuangCao")]
    public partial class QuangCao
    {
        [Key]
        public int MaQC { get; set; }

        [StringLength(50)]
        public string TenQC { get; set; }

        [StringLength(500)]
        public string AnhQC { get; set; }

        public int? STT { get; set; }
    }
}

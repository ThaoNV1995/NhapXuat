namespace NhapXuat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        [Key]
        public int MaSlide { get; set; }

        [StringLength(50)]
        public string TenSlide { get; set; }

        [StringLength(500)]
        public string AnhSlide { get; set; }

        public int? STT { get; set; }
    }
}

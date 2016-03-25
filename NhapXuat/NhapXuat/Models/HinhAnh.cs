namespace NhapXuat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnh")]
    public partial class HinhAnh
    {
        [Key]
        public int MaHA { get; set; }

        public int? MaSP { get; set; }

        [StringLength(250)]
        public string AnhSP { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}

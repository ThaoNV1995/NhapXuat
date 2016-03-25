namespace NhapXuat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int MaTin { get; set; }

        public int? MaDM { get; set; }

        [StringLength(100)]
        public string TieuDe { get; set; }

        [StringLength(250)]
        public string HinhAnh { get; set; }

        public string NoiDung { get; set; }

        public int? LuotXem { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public bool? HienThi { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}

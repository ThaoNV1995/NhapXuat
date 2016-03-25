namespace NhapXuat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDonNhap")]
    public partial class ChiTietHoaDonNhap
    {
        [Key]
        public int MaCTHDN { get; set; }

        public int? MaHDN { get; set; }

        public int? MaSP { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public int? ChietKhau { get; set; }

        public virtual HoaDonNhap HoaDonNhap { get; set; }
    }
}

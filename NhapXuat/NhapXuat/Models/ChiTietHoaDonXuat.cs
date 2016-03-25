namespace NhapXuat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDonXuat")]
    public partial class ChiTietHoaDonXuat
    {
        [Key]
        public int MaCTHDX { get; set; }

        public int? MaHDX { get; set; }

        public int? MaSP { get; set; }

        public int? SoLuong { get; set; }

        public int? DonGia { get; set; }

        public int? ChietKhau { get; set; }

        public virtual HoaDonXuat HoaDonXuat { get; set; }
    }
}

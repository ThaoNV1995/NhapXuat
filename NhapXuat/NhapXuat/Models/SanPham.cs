namespace NhapXuat.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            HinhAnh = new HashSet<HinhAnh>();
        }

        [Key]
        public int MaSP { get; set; }

        public int? MaTH { get; set; }

        public int? MaDM { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(250)]
        public string AnhSP { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        [StringLength(500)]
        public string KhuyenMai { get; set; }

        public string ChiTiet { get; set; }

        public int? GiaBan { get; set; }

        public int? GiaCu { get; set; }

        public int? BaoHanh { get; set; }

        public int? SoLuong { get; set; }

        public int? LuotXem { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public bool? HienThi { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HinhAnh> HinhAnh { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NhapXuat.Models;
using System.Web;
using PagedList;

namespace NhapXuat.DAO
{
    public class HoaDonXuatDAO
    {
        private readonly DataContext _db = new DataContext();

        //Lấy danh sách hóa đơn xuất
        public IEnumerable<HoaDonXuat> DanhSachHoaDonXuat(string text, int page, int pageSize)
        {
            IQueryable<HoaDonXuat> model = _db.HoaDonXuat;
            if (!string.IsNullOrEmpty(text))
            {
                model = model.Where(x => x.MaHDX.ToString().Contains(text));
            }
            return model.OrderByDescending(x => x.MaHDX).ToPagedList(page, pageSize);
        }

        // Thêm hóa đơn xuất
        public int ThemHoaDonXuat(HoaDonXuat dx)
        {
            _db.HoaDonXuat.Add(dx);
            _db.SaveChanges();
            return dx.MaHDX;
        }

        // Xem chi tiết một hóa đơn xuất
        public HoaDonXuat XemHoaDonXuat(int id)
        {
            return _db.HoaDonXuat.Find(id);
        }

        // Sửa xóa hóa đơn xuất
        public bool SuaHoaDonXuat(HoaDonXuat dx)
        {
            try
            {
                var ab = _db.HoaDonXuat.Find(dx.MaHDX);
                ab.MaHDX = dx.MaHDX;
                ab.MaKH = dx.MaKH;
                ab.MaNV = dx.MaNV;
                ab.NgayXuat = dx.NgayXuat;
                ab.NhanVien = dx.NhanVien;
                ab.KhachHang = dx.KhachHang;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Xóa  hóa đơn xuất
        public bool XoaHoaDonXuat(int id)
        {
            try
            {
                var dx = _db.HoaDonXuat.Find(id);
                _db.HoaDonXuat.Remove(dx);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
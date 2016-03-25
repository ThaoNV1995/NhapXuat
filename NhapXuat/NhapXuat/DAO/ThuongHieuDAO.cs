using System;
using System.Collections.Generic;
using System.Linq;
using NhapXuat.Models;
using System.Web;
using PagedList;

namespace NhapXuat.DAO
{
    public class ThuongHieuDAO
    {
        private readonly DataContext _db = new DataContext();

        //Lấy danh sách thương hiệu
        public IEnumerable<ThuongHieu> DanhSachThuongHieu(string text, int page, int pageSize)
        {
            IQueryable<ThuongHieu> model = _db.ThuongHieu;
            if (!string.IsNullOrEmpty(text))
            {
                model = model.Where(x => x.TenTH.ToString().Contains(text));
            }
            return model.OrderByDescending(x => x.MaTH).ToPagedList(page, pageSize);
        }

        // Thêm thương hiệu
        public int ThemThuongHieu(ThuongHieu dx)
        {
            _db.ThuongHieu.Add(dx);
            _db.SaveChanges();
            return dx.MaTH;
        }

        // Xem chi tiết một thương hiệu
        public ThuongHieu XemThuongHieu(int id)
        {
            return _db.ThuongHieu.Find(id);
        }

        // Sửa thương hiệu
        public bool SuaThuongHieu(ThuongHieu dx)
        {
            try
            {
                var ab = _db.ThuongHieu.Find(dx.MaTH);
                ab.MaTH = dx.MaTH;
                ab.TenTH = dx.TenTH;
                ab.Logo = dx.Logo;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Xóa  thương hiệu
        public bool XoaThuongHieu(int id)
        {
            try
            {
                var dx = _db.ThuongHieu.Find(id);
                _db.ThuongHieu.Remove(dx);
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
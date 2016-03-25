using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhapXuat.Models;

namespace NhapXuat.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/SanPham/
        public ActionResult Index()
        {
            var sanpham = db.SanPham.Include(s => s.DanhMuc).Include(s => s.ThuongHieu);
            return View(sanpham.ToList());
        }

        // GET: /Admin/SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanpham = db.SanPham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: /Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM");
            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH");
            return View();
        }

        // POST: /Admin/SanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaSP,MaTH,MaDM,TenSP,AnhSP,MoTa,KhuyenMai,ChiTiet,GiaBan,GiaCu,BaoHanh,SoLuong,LuotXem,NgayDang,NgayCapNhat,HienThi")] SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", sanpham.MaDM);
            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH", sanpham.MaTH);
            return View(sanpham);
        }

        // GET: /Admin/SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanpham = db.SanPham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", sanpham.MaDM);
            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH", sanpham.MaTH);
            return View(sanpham);
        }

        // POST: /Admin/SanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaSP,MaTH,MaDM,TenSP,AnhSP,MoTa,KhuyenMai,ChiTiet,GiaBan,GiaCu,BaoHanh,SoLuong,LuotXem,NgayDang,NgayCapNhat,HienThi")] SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", sanpham.MaDM);
            ViewBag.MaTH = new SelectList(db.ThuongHieu, "MaTH", "TenTH", sanpham.MaTH);
            return View(sanpham);
        }

        // GET: /Admin/SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanpham = db.SanPham.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: /Admin/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanpham = db.SanPham.Find(id);
            db.SanPham.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

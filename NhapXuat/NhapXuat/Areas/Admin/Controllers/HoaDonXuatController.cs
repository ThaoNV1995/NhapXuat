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
    public class HoaDonXuatController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/HoaDonXuat/
        public ActionResult Index()
        {
            var hoadonxuat = db.HoaDonXuat.Include(h => h.KhachHang).Include(h => h.NhanVien);
            return View(hoadonxuat.ToList());
        }

        // GET: /Admin/HoaDonXuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoadonxuat = db.HoaDonXuat.Find(id);
            if (hoadonxuat == null)
            {
                return HttpNotFound();
            }
            return View(hoadonxuat);
        }

        // GET: /Admin/HoaDonXuat/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH");
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV");
            return View();
        }

        // POST: /Admin/HoaDonXuat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaHDX,MaKH,MaNV,NgayXuat")] HoaDonXuat hoadonxuat)
        {
            if (ModelState.IsValid)
            {
                db.HoaDonXuat.Add(hoadonxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", hoadonxuat.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV", hoadonxuat.MaNV);
            return View(hoadonxuat);
        }

        // GET: /Admin/HoaDonXuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoadonxuat = db.HoaDonXuat.Find(id);
            if (hoadonxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", hoadonxuat.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV", hoadonxuat.MaNV);
            return View(hoadonxuat);
        }

        // POST: /Admin/HoaDonXuat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaHDX,MaKH,MaNV,NgayXuat")] HoaDonXuat hoadonxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoadonxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHang, "MaKH", "TenKH", hoadonxuat.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanVien, "MaNV", "TenNV", hoadonxuat.MaNV);
            return View(hoadonxuat);
        }

        // GET: /Admin/HoaDonXuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonXuat hoadonxuat = db.HoaDonXuat.Find(id);
            if (hoadonxuat == null)
            {
                return HttpNotFound();
            }
            return View(hoadonxuat);
        }

        // POST: /Admin/HoaDonXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDonXuat hoadonxuat = db.HoaDonXuat.Find(id);
            db.HoaDonXuat.Remove(hoadonxuat);
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

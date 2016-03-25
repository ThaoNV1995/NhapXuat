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
    public class NhanVienController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/NhanVien/
        public ActionResult Index()
        {
            var nhanvien = db.NhanVien.Include(n => n.Quyen);
            return View(nhanvien.ToList());
        }

        // GET: /Admin/NhanVien/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.NhanVien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // GET: /Admin/NhanVien/Create
        public ActionResult Create()
        {
            ViewBag.MaQuyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen");
            return View();
        }

        // POST: /Admin/NhanVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaNV,MaQuyen,TenNV,TenDangNhap,MatKhau")] NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.NhanVien.Add(nhanvien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaQuyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen", nhanvien.MaQuyen);
            return View(nhanvien);
        }

        // GET: /Admin/NhanVien/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.NhanVien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaQuyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen", nhanvien.MaQuyen);
            return View(nhanvien);
        }

        // POST: /Admin/NhanVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaNV,MaQuyen,TenNV,TenDangNhap,MatKhau")] NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaQuyen = new SelectList(db.Quyen, "MaQuyen", "TenQuyen", nhanvien.MaQuyen);
            return View(nhanvien);
        }

        // GET: /Admin/NhanVien/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanvien = db.NhanVien.Find(id);
            if (nhanvien == null)
            {
                return HttpNotFound();
            }
            return View(nhanvien);
        }

        // POST: /Admin/NhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhanVien nhanvien = db.NhanVien.Find(id);
            db.NhanVien.Remove(nhanvien);
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

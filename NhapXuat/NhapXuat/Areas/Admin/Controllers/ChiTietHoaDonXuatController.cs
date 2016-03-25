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
    public class ChiTietHoaDonXuatController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/ChiTietHoaDonXuat/
        public ActionResult Index()
        {
            var chitiethoadonxuat = db.ChiTietHoaDonXuat.Include(c => c.HoaDonXuat);
            return View(chitiethoadonxuat.ToList());
        }

        // GET: /Admin/ChiTietHoaDonXuat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonXuat chitiethoadonxuat = db.ChiTietHoaDonXuat.Find(id);
            if (chitiethoadonxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadonxuat);
        }

        // GET: /Admin/ChiTietHoaDonXuat/Create
        public ActionResult Create()
        {
            ViewBag.MaHDX = new SelectList(db.HoaDonXuat, "MaHDX", "MaHDX");
            return View();
        }

        // POST: /Admin/ChiTietHoaDonXuat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaCTHDX,MaHDX,MaSP,SoLuong,DonGia,ChietKhau")] ChiTietHoaDonXuat chitiethoadonxuat)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDonXuat.Add(chitiethoadonxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHDX = new SelectList(db.HoaDonXuat, "MaHDX", "MaHDX", chitiethoadonxuat.MaHDX);
            return View(chitiethoadonxuat);
        }

        // GET: /Admin/ChiTietHoaDonXuat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonXuat chitiethoadonxuat = db.ChiTietHoaDonXuat.Find(id);
            if (chitiethoadonxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDX = new SelectList(db.HoaDonXuat, "MaHDX", "MaHDX", chitiethoadonxuat.MaHDX);
            return View(chitiethoadonxuat);
        }

        // POST: /Admin/ChiTietHoaDonXuat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaCTHDX,MaHDX,MaSP,SoLuong,DonGia,ChietKhau")] ChiTietHoaDonXuat chitiethoadonxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiethoadonxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHDX = new SelectList(db.HoaDonXuat, "MaHDX", "MaHDX", chitiethoadonxuat.MaHDX);
            return View(chitiethoadonxuat);
        }

        // GET: /Admin/ChiTietHoaDonXuat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonXuat chitiethoadonxuat = db.ChiTietHoaDonXuat.Find(id);
            if (chitiethoadonxuat == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadonxuat);
        }

        // POST: /Admin/ChiTietHoaDonXuat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHoaDonXuat chitiethoadonxuat = db.ChiTietHoaDonXuat.Find(id);
            db.ChiTietHoaDonXuat.Remove(chitiethoadonxuat);
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

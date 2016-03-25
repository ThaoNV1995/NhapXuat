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
    public class ChiTietHoaDonNhapController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/ChiTietHoaDonNhap/
        public ActionResult Index()
        {
            var chitiethoadonnhap = db.ChiTietHoaDonNhap.Include(c => c.HoaDonNhap);
            return View(chitiethoadonnhap.ToList());
        }

        // GET: /Admin/ChiTietHoaDonNhap/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonNhap chitiethoadonnhap = db.ChiTietHoaDonNhap.Find(id);
            if (chitiethoadonnhap == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadonnhap);
        }

        // GET: /Admin/ChiTietHoaDonNhap/Create
        public ActionResult Create()
        {
            ViewBag.MaHDN = new SelectList(db.HoaDonNhap, "MaHDN", "MaHDN");
            return View();
        }

        // POST: /Admin/ChiTietHoaDonNhap/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaCTHDN,MaHDN,MaSP,SoLuong,DonGia,ChietKhau")] ChiTietHoaDonNhap chitiethoadonnhap)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHoaDonNhap.Add(chitiethoadonnhap);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHDN = new SelectList(db.HoaDonNhap, "MaHDN", "MaHDN", chitiethoadonnhap.MaHDN);
            return View(chitiethoadonnhap);
        }

        // GET: /Admin/ChiTietHoaDonNhap/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonNhap chitiethoadonnhap = db.ChiTietHoaDonNhap.Find(id);
            if (chitiethoadonnhap == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHDN = new SelectList(db.HoaDonNhap, "MaHDN", "MaHDN", chitiethoadonnhap.MaHDN);
            return View(chitiethoadonnhap);
        }

        // POST: /Admin/ChiTietHoaDonNhap/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaCTHDN,MaHDN,MaSP,SoLuong,DonGia,ChietKhau")] ChiTietHoaDonNhap chitiethoadonnhap)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chitiethoadonnhap).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHDN = new SelectList(db.HoaDonNhap, "MaHDN", "MaHDN", chitiethoadonnhap.MaHDN);
            return View(chitiethoadonnhap);
        }

        // GET: /Admin/ChiTietHoaDonNhap/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHoaDonNhap chitiethoadonnhap = db.ChiTietHoaDonNhap.Find(id);
            if (chitiethoadonnhap == null)
            {
                return HttpNotFound();
            }
            return View(chitiethoadonnhap);
        }

        // POST: /Admin/ChiTietHoaDonNhap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietHoaDonNhap chitiethoadonnhap = db.ChiTietHoaDonNhap.Find(id);
            db.ChiTietHoaDonNhap.Remove(chitiethoadonnhap);
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

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
    public class HinhAnhController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/HinhAnh/
        public ActionResult Index()
        {
            var hinhanh = db.HinhAnh.Include(h => h.SanPham);
            return View(hinhanh.ToList());
        }

        // GET: /Admin/HinhAnh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhanh = db.HinhAnh.Find(id);
            if (hinhanh == null)
            {
                return HttpNotFound();
            }
            return View(hinhanh);
        }

        // GET: /Admin/HinhAnh/Create
        public ActionResult Create()
        {
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP");
            return View();
        }

        // POST: /Admin/HinhAnh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaHA,MaSP,AnhSP")] HinhAnh hinhanh)
        {
            if (ModelState.IsValid)
            {
                db.HinhAnh.Add(hinhanh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", hinhanh.MaSP);
            return View(hinhanh);
        }

        // GET: /Admin/HinhAnh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhanh = db.HinhAnh.Find(id);
            if (hinhanh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", hinhanh.MaSP);
            return View(hinhanh);
        }

        // POST: /Admin/HinhAnh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaHA,MaSP,AnhSP")] HinhAnh hinhanh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hinhanh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSP = new SelectList(db.SanPham, "MaSP", "TenSP", hinhanh.MaSP);
            return View(hinhanh);
        }

        // GET: /Admin/HinhAnh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HinhAnh hinhanh = db.HinhAnh.Find(id);
            if (hinhanh == null)
            {
                return HttpNotFound();
            }
            return View(hinhanh);
        }

        // POST: /Admin/HinhAnh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HinhAnh hinhanh = db.HinhAnh.Find(id);
            db.HinhAnh.Remove(hinhanh);
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

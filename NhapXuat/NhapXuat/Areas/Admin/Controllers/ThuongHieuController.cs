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
    public class ThuongHieuController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/ThuongHieu/
        public ActionResult Index()
        {
            return View(db.ThuongHieu.ToList());
        }

        // GET: /Admin/ThuongHieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuongHieu thuonghieu = db.ThuongHieu.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // GET: /Admin/ThuongHieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/ThuongHieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaTH,TenTH,Logo")] ThuongHieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.ThuongHieu.Add(thuonghieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thuonghieu);
        }

        // GET: /Admin/ThuongHieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuongHieu thuonghieu = db.ThuongHieu.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // POST: /Admin/ThuongHieu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaTH,TenTH,Logo")] ThuongHieu thuonghieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuonghieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuonghieu);
        }

        // GET: /Admin/ThuongHieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThuongHieu thuonghieu = db.ThuongHieu.Find(id);
            if (thuonghieu == null)
            {
                return HttpNotFound();
            }
            return View(thuonghieu);
        }

        // POST: /Admin/ThuongHieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThuongHieu thuonghieu = db.ThuongHieu.Find(id);
            db.ThuongHieu.Remove(thuonghieu);
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

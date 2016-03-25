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
    public class TinTucController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/TinTuc/
        public ActionResult Index()
        {
            var tintuc = db.TinTuc.Include(t => t.DanhMuc);
            return View(tintuc.ToList());
        }

        // GET: /Admin/TinTuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tintuc = db.TinTuc.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: /Admin/TinTuc/Create
        public ActionResult Create()
        {
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM");
            return View();
        }

        // POST: /Admin/TinTuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaTin,MaDM,TieuDe,HinhAnh,NoiDung,LuotXem,NgayDang,NgayCapNhat,HienThi")] TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.TinTuc.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", tintuc.MaDM);
            return View(tintuc);
        }

        // GET: /Admin/TinTuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tintuc = db.TinTuc.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", tintuc.MaDM);
            return View(tintuc);
        }

        // POST: /Admin/TinTuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaTin,MaDM,TieuDe,HinhAnh,NoiDung,LuotXem,NgayDang,NgayCapNhat,HienThi")] TinTuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDM = new SelectList(db.DanhMuc, "MaDM", "TenDM", tintuc.MaDM);
            return View(tintuc);
        }

        // GET: /Admin/TinTuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tintuc = db.TinTuc.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: /Admin/TinTuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TinTuc tintuc = db.TinTuc.Find(id);
            db.TinTuc.Remove(tintuc);
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

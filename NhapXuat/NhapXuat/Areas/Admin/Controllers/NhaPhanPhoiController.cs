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
    public class NhaPhanPhoiController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/NhaPhanPhoi/
        public ActionResult Index()
        {
            return View(db.NhaPhanPhoi.ToList());
        }

        // GET: /Admin/NhaPhanPhoi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaPhanPhoi nhaphanphoi = db.NhaPhanPhoi.Find(id);
            if (nhaphanphoi == null)
            {
                return HttpNotFound();
            }
            return View(nhaphanphoi);
        }

        // GET: /Admin/NhaPhanPhoi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/NhaPhanPhoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaNPP,TenNPP,NguoiLienHe,DiaChi,DienThoai,Fax,Email,Website")] NhaPhanPhoi nhaphanphoi)
        {
            if (ModelState.IsValid)
            {
                db.NhaPhanPhoi.Add(nhaphanphoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaphanphoi);
        }

        // GET: /Admin/NhaPhanPhoi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaPhanPhoi nhaphanphoi = db.NhaPhanPhoi.Find(id);
            if (nhaphanphoi == null)
            {
                return HttpNotFound();
            }
            return View(nhaphanphoi);
        }

        // POST: /Admin/NhaPhanPhoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaNPP,TenNPP,NguoiLienHe,DiaChi,DienThoai,Fax,Email,Website")] NhaPhanPhoi nhaphanphoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaphanphoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaphanphoi);
        }

        // GET: /Admin/NhaPhanPhoi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaPhanPhoi nhaphanphoi = db.NhaPhanPhoi.Find(id);
            if (nhaphanphoi == null)
            {
                return HttpNotFound();
            }
            return View(nhaphanphoi);
        }

        // POST: /Admin/NhaPhanPhoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhaPhanPhoi nhaphanphoi = db.NhaPhanPhoi.Find(id);
            db.NhaPhanPhoi.Remove(nhaphanphoi);
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

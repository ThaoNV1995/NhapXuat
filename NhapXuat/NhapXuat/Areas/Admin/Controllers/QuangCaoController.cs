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
    public class QuangCaoController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Admin/QuangCao/
        public ActionResult Index()
        {
            return View(db.QuangCao.ToList());
        }

        // GET: /Admin/QuangCao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuangCao quangcao = db.QuangCao.Find(id);
            if (quangcao == null)
            {
                return HttpNotFound();
            }
            return View(quangcao);
        }

        // GET: /Admin/QuangCao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/QuangCao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MaQC,TenQC,AnhQC,STT")] QuangCao quangcao)
        {
            if (ModelState.IsValid)
            {
                db.QuangCao.Add(quangcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quangcao);
        }

        // GET: /Admin/QuangCao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuangCao quangcao = db.QuangCao.Find(id);
            if (quangcao == null)
            {
                return HttpNotFound();
            }
            return View(quangcao);
        }

        // POST: /Admin/QuangCao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MaQC,TenQC,AnhQC,STT")] QuangCao quangcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quangcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quangcao);
        }

        // GET: /Admin/QuangCao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuangCao quangcao = db.QuangCao.Find(id);
            if (quangcao == null)
            {
                return HttpNotFound();
            }
            return View(quangcao);
        }

        // POST: /Admin/QuangCao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuangCao quangcao = db.QuangCao.Find(id);
            db.QuangCao.Remove(quangcao);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CliMed.Persistencia;

namespace CliMed.Controllers
{
    public class UsuarioController : Controller
    {
        private DB_A32723_CLIMEDEntities db = new DB_A32723_CLIMEDEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(db.TB_USUARIO.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CD_USUARIO,NM_USUARIO,DS_LOGIN,DS_SENHA,FL_ATIVO")] TB_USUARIO tB_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TB_USUARIO.Add(tB_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_USUARIO);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CD_USUARIO,NM_USUARIO,DS_LOGIN,DS_SENHA,FL_ATIVO")] TB_USUARIO tB_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_USUARIO);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            if (tB_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tB_USUARIO);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_USUARIO tB_USUARIO = db.TB_USUARIO.Find(id);
            db.TB_USUARIO.Remove(tB_USUARIO);
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

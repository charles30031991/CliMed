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
    public class AtendimentoController : Controller
    {
        private DB_A32723_CLIMEDEntities db = new DB_A32723_CLIMEDEntities();

        // GET: Atendimento
        public ActionResult Index()
        {
            var tB_ATENDIMENTO = db.TB_ATENDIMENTO.Include(t => t.TB_AGENDA).Include(t => t.TB_USUARIO);
            return View(tB_ATENDIMENTO.ToList());
        }

        // GET: Atendimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ATENDIMENTO tB_ATENDIMENTO = db.TB_ATENDIMENTO.Find(id);
            if (tB_ATENDIMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ATENDIMENTO);
        }

        // GET: Atendimento/Create
        public ActionResult Create()
        {
            ViewBag.CD_AGENDA = new SelectList(db.TB_AGENDA, "CD_AGENDA", "DS_OBSERVACAO");
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO");
            return View();
        }

        // POST: Atendimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CD_ATENDIMENTO,CD_AGENDA,CD_USUARIO,DT_DATA,DS_DOENCA,DS_MEDICAMENTOS")] TB_ATENDIMENTO tB_ATENDIMENTO)
        {
            if (ModelState.IsValid)
            {
                db.TB_ATENDIMENTO.Add(tB_ATENDIMENTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CD_AGENDA = new SelectList(db.TB_AGENDA, "CD_AGENDA", "DS_OBSERVACAO", tB_ATENDIMENTO.CD_AGENDA);
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO", tB_ATENDIMENTO.CD_USUARIO);
            return View(tB_ATENDIMENTO);
        }

        // GET: Atendimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ATENDIMENTO tB_ATENDIMENTO = db.TB_ATENDIMENTO.Find(id);
            if (tB_ATENDIMENTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CD_AGENDA = new SelectList(db.TB_AGENDA, "CD_AGENDA", "DS_OBSERVACAO", tB_ATENDIMENTO.CD_AGENDA);
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO", tB_ATENDIMENTO.CD_USUARIO);
            return View(tB_ATENDIMENTO);
        }

        // POST: Atendimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CD_ATENDIMENTO,CD_AGENDA,CD_USUARIO,DT_DATA,DS_DOENCA,DS_MEDICAMENTOS")] TB_ATENDIMENTO tB_ATENDIMENTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_ATENDIMENTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CD_AGENDA = new SelectList(db.TB_AGENDA, "CD_AGENDA", "DS_OBSERVACAO", tB_ATENDIMENTO.CD_AGENDA);
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO", tB_ATENDIMENTO.CD_USUARIO);
            return View(tB_ATENDIMENTO);
        }

        // GET: Atendimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_ATENDIMENTO tB_ATENDIMENTO = db.TB_ATENDIMENTO.Find(id);
            if (tB_ATENDIMENTO == null)
            {
                return HttpNotFound();
            }
            return View(tB_ATENDIMENTO);
        }

        // POST: Atendimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_ATENDIMENTO tB_ATENDIMENTO = db.TB_ATENDIMENTO.Find(id);
            db.TB_ATENDIMENTO.Remove(tB_ATENDIMENTO);
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

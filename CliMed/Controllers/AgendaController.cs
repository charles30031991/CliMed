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
    public class AgendaController : Controller
    {
        private DB_A32723_CLIMEDEntities db = new DB_A32723_CLIMEDEntities();

        // GET: Agenda
        public ActionResult Index()
        {
            var tB_AGENDA = db.TB_AGENDA.Include(t => t.TB_PACIENTE).Include(t => t.TB_SITUACAO_AGENDA).Include(t => t.TB_TIPO_SERVICO).Include(t => t.TB_USUARIO);
            return View(tB_AGENDA.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AGENDA tB_AGENDA = db.TB_AGENDA.Find(id);
            if (tB_AGENDA == null)
            {
                return HttpNotFound();
            }
            return View(tB_AGENDA);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.CD_PACIENTE = new SelectList(db.TB_PACIENTE, "CD_PACIENTE", "NM_PACIENTE");
            ViewBag.CD_SITUACAO_AGENDA = new SelectList(db.TB_SITUACAO_AGENDA, "CD_SITUACAO_AGENDA", "NM_SITUACAO_AGENDA");
            ViewBag.CD_TIPO_SERVICO = new SelectList(db.TB_TIPO_SERVICO, "CD_TIPO_SERVICO", "NM_TIPO_SERVICO");
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CD_AGENDA,CD_PACIENTE,CD_TIPO_SERVICO,CD_USUARIO,CD_SITUACAO_AGENDA,DT_DATA,DS_OBSERVACAO,VL_VALOR")] TB_AGENDA tB_AGENDA)
        {
            if (ModelState.IsValid)
            {
                db.TB_AGENDA.Add(tB_AGENDA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CD_PACIENTE = new SelectList(db.TB_PACIENTE, "CD_PACIENTE", "NM_PACIENTE", tB_AGENDA.CD_PACIENTE);
            ViewBag.CD_SITUACAO_AGENDA = new SelectList(db.TB_SITUACAO_AGENDA, "CD_SITUACAO_AGENDA", "NM_SITUACAO_AGENDA", tB_AGENDA.CD_SITUACAO_AGENDA);
            ViewBag.CD_TIPO_SERVICO = new SelectList(db.TB_TIPO_SERVICO, "CD_TIPO_SERVICO", "NM_TIPO_SERVICO", tB_AGENDA.CD_TIPO_SERVICO);
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO", tB_AGENDA.CD_USUARIO);
            return View(tB_AGENDA);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AGENDA tB_AGENDA = db.TB_AGENDA.Find(id);
            if (tB_AGENDA == null)
            {
                return HttpNotFound();
            }
            ViewBag.CD_PACIENTE = new SelectList(db.TB_PACIENTE, "CD_PACIENTE", "NM_PACIENTE", tB_AGENDA.CD_PACIENTE);
            ViewBag.CD_SITUACAO_AGENDA = new SelectList(db.TB_SITUACAO_AGENDA, "CD_SITUACAO_AGENDA", "NM_SITUACAO_AGENDA", tB_AGENDA.CD_SITUACAO_AGENDA);
            ViewBag.CD_TIPO_SERVICO = new SelectList(db.TB_TIPO_SERVICO, "CD_TIPO_SERVICO", "NM_TIPO_SERVICO", tB_AGENDA.CD_TIPO_SERVICO);
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO", tB_AGENDA.CD_USUARIO);
            return View(tB_AGENDA);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CD_AGENDA,CD_PACIENTE,CD_TIPO_SERVICO,CD_USUARIO,CD_SITUACAO_AGENDA,DT_DATA,DS_OBSERVACAO,VL_VALOR")] TB_AGENDA tB_AGENDA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_AGENDA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CD_PACIENTE = new SelectList(db.TB_PACIENTE, "CD_PACIENTE", "NM_PACIENTE", tB_AGENDA.CD_PACIENTE);
            ViewBag.CD_SITUACAO_AGENDA = new SelectList(db.TB_SITUACAO_AGENDA, "CD_SITUACAO_AGENDA", "NM_SITUACAO_AGENDA", tB_AGENDA.CD_SITUACAO_AGENDA);
            ViewBag.CD_TIPO_SERVICO = new SelectList(db.TB_TIPO_SERVICO, "CD_TIPO_SERVICO", "NM_TIPO_SERVICO", tB_AGENDA.CD_TIPO_SERVICO);
            ViewBag.CD_USUARIO = new SelectList(db.TB_USUARIO, "CD_USUARIO", "NM_USUARIO", tB_AGENDA.CD_USUARIO);
            return View(tB_AGENDA);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_AGENDA tB_AGENDA = db.TB_AGENDA.Find(id);
            if (tB_AGENDA == null)
            {
                return HttpNotFound();
            }
            return View(tB_AGENDA);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_AGENDA tB_AGENDA = db.TB_AGENDA.Find(id);
            db.TB_AGENDA.Remove(tB_AGENDA);
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

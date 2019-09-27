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
    public class PacienteController : Controller
    {
        private DB_A32723_CLIMEDEntities db = new DB_A32723_CLIMEDEntities();

        // GET: Paciente
        public ActionResult Index()
        {
            return View(db.TB_PACIENTE.ToList());
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            if (tB_PACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_PACIENTE);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CD_PACIENTE,NM_PACIENTE,DS_CPF,DS_RG,DS_TELEFONE,DT_NASCIMENTO,DS_CEP,DS_UF,DS_CIDADE,DS_ENDERECO,DS_BAIRRO")] TB_PACIENTE tB_PACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.TB_PACIENTE.Add(tB_PACIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_PACIENTE);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            if (tB_PACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_PACIENTE);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CD_PACIENTE,NM_PACIENTE,DS_CPF,DS_RG,DS_TELEFONE,DT_NASCIMENTO,DS_CEP,DS_UF,DS_CIDADE,DS_ENDERECO,DS_BAIRRO")] TB_PACIENTE tB_PACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PACIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_PACIENTE);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            if (tB_PACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_PACIENTE);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            db.TB_PACIENTE.Remove(tB_PACIENTE);
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

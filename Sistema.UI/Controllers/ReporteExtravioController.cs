using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema.Model;

namespace Sistema.UI.Controllers
{
    public class ReporteExtravioController : Controller
    {
        private SistemaSeguridadEntities db = new SistemaSeguridadEntities();

        // GET: ReporteExtravio
        public ActionResult Index()
        {
            var reporteExtravio = db.ReporteExtravio.Include(r => r.Usuario);
            return View(reporteExtravio.ToList());
        }

        // GET: ReporteExtravio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReporteExtravio reporteExtravio = db.ReporteExtravio.Find(id);
            if (reporteExtravio == null)
            {
                return HttpNotFound();
            }
            return View(reporteExtravio);
        }

        // GET: ReporteExtravio/Create
        public ActionResult Create()
        {

            var elModelo = new Usuario()
            {

                IdRol = 3,
            };

            ViewBag.IdUsuario = new SelectList(db.Usuario.Where(u => u.IdRol == elModelo.IdRol), "idUsuario", "Nombre");
      
            return View();
        }

        // POST: ReporteExtravio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReporte,IdUsuario,Fecha,Descripcion,Celular,Email,NombreContacto")] ReporteExtravio reporteExtravio)
        {
            if (ModelState.IsValid)
            {
                db.ReporteExtravio.Add(reporteExtravio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuario, "idUsuario", "Nombre", reporteExtravio.IdUsuario);
            return View(reporteExtravio);
        }

        // GET: ReporteExtravio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReporteExtravio reporteExtravio = db.ReporteExtravio.Find(id);
            if (reporteExtravio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "idUsuario", "Nombre", reporteExtravio.IdUsuario);
            return View(reporteExtravio);
        }

        // POST: ReporteExtravio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReporte,IdUsuario,Fecha,Descripcion,Celular,Email,NombreContacto")] ReporteExtravio reporteExtravio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporteExtravio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "idUsuario", "Nombre", reporteExtravio.IdUsuario);
            return View(reporteExtravio);
        }

        // GET: ReporteExtravio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReporteExtravio reporteExtravio = db.ReporteExtravio.Find(id);
            if (reporteExtravio == null)
            {
                return HttpNotFound();
            }
            return View(reporteExtravio);
        }

        // POST: ReporteExtravio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReporteExtravio reporteExtravio = db.ReporteExtravio.Find(id);
            db.ReporteExtravio.Remove(reporteExtravio);
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

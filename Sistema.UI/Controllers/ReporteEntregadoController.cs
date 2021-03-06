﻿using System;
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
    public class ReporteEntregadoController : Controller
    {
        private SistemaSeguridadEntities db = new SistemaSeguridadEntities();

        // GET: ReporteEntregado
        public ActionResult Index()
        {
            var reporteEntregado = db.ReporteEntregado.Include(r => r.Articulo).Include(r => r.Usuario);
            return View(reporteEntregado.ToList());
        }



        public ActionResult BusquedaFecha(Nullable<DateTime> FechaInicial, Nullable<DateTime> FechaFinal)
        {
            
            var reporte = from s in db.ReporteEntregado select s;

            if (!String.IsNullOrEmpty(FechaInicial.ToString()) || !String.IsNullOrEmpty(FechaFinal.ToString()))
            {

                //catego = catego.Where(s => s.Categoria.IdCategoria == Convert.ToInt32(Categoria));

                return View("Index", reporte.ToList().Where(x => x.Fecha >= FechaInicial & x.Fecha <= FechaFinal).OrderBy(x=> x.Fecha));
            }
            else
            {
                return View("Index", reporte.ToList());
            }


        }






        // GET: ReporteEntregado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReporteEntregado reporteEntregado = db.ReporteEntregado.Find(id);
            if (reporteEntregado == null)
            {
                return HttpNotFound();
            }
            return View(reporteEntregado);
        }

        // GET: ReporteEntregado/Create
        public ActionResult Create()
        {
            ViewBag.IdArticulo = new SelectList(db.Articulo.Where(a => a.IdEstado == 1), "IdArticulo", "Descripcion");
            ViewBag.IdUsuario = new SelectList(db.Usuario.Where(u => u.IdRol== 3), "idUsuario", "Nombre");
            return View();
        }

        // POST: ReporteEntregado/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEntrega,IdUsuario,Fecha,IdArticulo,Celular,Email")] ReporteEntregado reporteEntregado)
        {
            if (ModelState.IsValid)
            {
                db.ReporteEntregado.Add(reporteEntregado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdArticulo = new SelectList(db.Articulo.Where(a => a.IdEstado == 1), "IdArticulo", "Descripcion", reporteEntregado.IdArticulo);
            ViewBag.IdUsuario = new SelectList(db.Usuario.Where(u => u.IdRol == 3), "idUsuario", "Nombre", reporteEntregado.IdUsuario);
            return View(reporteEntregado);
        }

        // GET: ReporteEntregado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReporteEntregado reporteEntregado = db.ReporteEntregado.Find(id);
            if (reporteEntregado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdArticulo = new SelectList(db.Articulo.Where(a => a.IdEstado == 1), "IdArticulo", "Descripcion", reporteEntregado.IdArticulo);
            ViewBag.IdUsuario = new SelectList(db.Usuario.Where(u => u.IdRol == 3), "idUsuario", "Nombre", reporteEntregado.IdUsuario);
            return View(reporteEntregado);
        }

        // POST: ReporteEntregado/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEntrega,IdUsuario,Fecha,IdArticulo,Celular,Email")] ReporteEntregado reporteEntregado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reporteEntregado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdArticulo = new SelectList(db.Articulo.Where(a => a.IdEstado == 1), "IdArticulo", "Descripcion", reporteEntregado.IdArticulo);
            ViewBag.IdUsuario = new SelectList(db.Usuario.Where(u => u.IdRol == 3), "idUsuario", "Nombre", reporteEntregado.IdUsuario);
            return View(reporteEntregado);
        }

        // GET: ReporteEntregado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReporteEntregado reporteEntregado = db.ReporteEntregado.Find(id);
            if (reporteEntregado == null)
            {
                return HttpNotFound();
            }
            return View(reporteEntregado);
        }

        // POST: ReporteEntregado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReporteEntregado reporteEntregado = db.ReporteEntregado.Find(id);
            db.ReporteEntregado.Remove(reporteEntregado);
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

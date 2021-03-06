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
    public class ArticuloController : Controller
    {
        private SistemaSeguridadEntities db = new SistemaSeguridadEntities();

        // GET: Articulo
        public ActionResult Index()
        {
           
            var elModelo = new Articulo()
            {

                IdEstado = 1,
            };


            ViewBag.Categoria = new SelectList(db.Categoria, "IdCategoria", "Descripcion");

            var articulo = db.Articulo.Include(a => a.Categoria).Include(a => a.Estado).Where(a => a.IdEstado == elModelo.IdEstado);

               
            return View(articulo.ToList());
        }

        //Prueba de busqueda
     
     public ActionResult BusquedaCategoria(String Categoria)
     {
         ViewBag.Categoria = new SelectList(db.Categoria, "IdCategoria","Descripcion");
         var catego = from s in db.Articulo.Include(a => a.Categoria) select s;

         if (!String.IsNullOrEmpty(Categoria))
         {
               
                //catego = catego.Where(s => s.Categoria.IdCategoria == Convert.ToInt32(Categoria));

                return View("Index", catego.ToList().Where(x => x.IdCategoria == Convert.ToInt32(Categoria) & x.IdEstado == 1));
            }
            else
            {
                return View("Index", catego.ToList().Where(a => a.IdEstado == 1));
            }

        
     }
     

        /*
        [HttpPost]
        public ActionResult Buscador(Articulo Nombre)
        {
            var busqueda = from s in db.Personas select s;

            if (!String.IsNullOrEmpty(Nombre))
            {
                busqueda = busqueda.Where(s => s.Nombre.Contains(Nombre)
                                       || s.Apellidos.Contains(Nombre));
            }
            return View(busqueda.ToList());
        }
        */

        // GET: Articulo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // GET: Articulo/Create
        public ActionResult Create()
        {
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descripcion");
            ViewBag.IdEstado = new SelectList(db.Estado, "idEstado", "Descripcion");
            return View();
        }

        // POST: Articulo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdArticulo,IdCategoria,IdEstado,Marca,Descripcion,Foto")] Articulo articulo)
        {



            if (ModelState.IsValid)
            {
                try
                {

                db.Articulo.Add(articulo);
                db.SaveChanges();
                }
                catch (Exception)
                {

                   return View();
                }
               
                return RedirectToAction("Index");
            }

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descripcion", articulo.IdCategoria);
            ViewBag.IdEstado = new SelectList(db.Estado, "idEstado", "Descripcion", articulo.IdEstado);
            return View(articulo);
        }

        // GET: Articulo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }

         

            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descripcion", articulo.IdCategoria);
            ViewBag.IdEstado = new SelectList(db.Estado.Where(e => e.idEstado == 2 | e.idEstado == 3), "idEstado", "Descripcion", articulo.IdEstado);
            return View(articulo);
        }

        // POST: Articulo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdArticulo,IdCategoria,IdEstado,Marca,Descripcion,Foto")] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCategoria = new SelectList(db.Categoria, "IdCategoria", "Descripcion", articulo.IdCategoria);
            ViewBag.IdEstado = new SelectList(db.Estado, "idEstado", "Descripcion", articulo.IdEstado);
            return View(articulo);
        }

        // GET: Articulo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articulo articulo = db.Articulo.Find(id);
            if (articulo == null)
            {
                return HttpNotFound();
            }
            return View(articulo);
        }

        // POST: Articulo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articulo articulo = db.Articulo.Find(id);
            db.Articulo.Remove(articulo);
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

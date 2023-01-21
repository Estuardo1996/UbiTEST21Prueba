using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UbiTEST21.Models;

namespace UbiTEST21.Controllers
{
    public class PlatoesController : Controller
    {
        private PruebaDBUBIEntities db = new PruebaDBUBIEntities();

        // GET: Platoes
        public ActionResult Index()
        {
            return View(db.Plato.Where(x => x.Precio > 8 && x.Precio < 26 && x.FechaCreacion >= DateTime.Today ).ToList());
        }

        // GET: Platoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plato plato = db.Plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // GET: Platoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Platoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Descripcion,Precio,Estado,UsuarioCreacion,FechaCreacion,UsuarioActualiza,FechaActualiza")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                if (plato.Nombre.Length > 4 )
                {
                    db.Plato.Add(plato);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
             
            }

            return View(plato);
        }

        // GET: Platoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plato plato = db.Plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // POST: Platoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Descripcion,Precio,Estado,UsuarioCreacion,FechaCreacion,UsuarioActualiza,FechaActualiza")] Plato plato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plato);
        }

        // GET: Platoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plato plato = db.Plato.Find(id);
            if (plato == null)
            {
                return HttpNotFound();
            }
            return View(plato);
        }

        // POST: Platoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plato plato = db.Plato.Find(id);
            db.Plato.Remove(plato);
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

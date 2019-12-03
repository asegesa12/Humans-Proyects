using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StarWars.Models;

namespace StarWars.Controllers
{
    public class SalidasController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Salidas
        public ActionResult Index()
        {
            var salidas = db.salidas.Include(s => s.Empleado);
            return View(salidas.ToList());
        }

        // GET: Salidas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // GET: Salidas/Create
        public ActionResult Create()
        {
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre");
            return View();
        }

        // POST: Salidas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoSalida,CodigoEmpleado,Tipo,Motivo")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                db.salidas.Add(salida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", salida.CodigoEmpleado);
            return View(salida);
        }

        // GET: Salidas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", salida.CodigoEmpleado);
            return View(salida);
        }

        // POST: Salidas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoSalida,CodigoEmpleado,Tipo,Motivo")] Salida salida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", salida.CodigoEmpleado);
            return View(salida);
        }

        // GET: Salidas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salida salida = db.salidas.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // POST: Salidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Salida salida = db.salidas.Find(id);
            db.salidas.Remove(salida);
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

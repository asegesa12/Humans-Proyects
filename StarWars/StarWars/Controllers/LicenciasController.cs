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
    public class LicenciasController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Licencias
        public ActionResult Index()
        {
            var licencias = db.licencias.Include(l => l.Empleado);
            return View(licencias.ToList());
        }

        // GET: Licencias/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencia licencia = db.licencias.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // GET: Licencias/Create
        public ActionResult Create()
        {
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre");
            return View();
        }

        // POST: Licencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoFecha,CodigoEmpleado,FechaEntrada,FechaSalida,Comentario")] Licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.licencias.Add(licencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", licencia.CodigoEmpleado);
            return View(licencia);
        }

        // GET: Licencias/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencia licencia = db.licencias.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", licencia.CodigoEmpleado);
            return View(licencia);
        }

        // POST: Licencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoFecha,CodigoEmpleado,FechaEntrada,FechaSalida,Comentario")] Licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", licencia.CodigoEmpleado);
            return View(licencia);
        }

        // GET: Licencias/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Licencia licencia = db.licencias.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // POST: Licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Licencia licencia = db.licencias.Find(id);
            db.licencias.Remove(licencia);
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

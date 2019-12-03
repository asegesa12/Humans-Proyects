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
    public class PermisosController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Permisos
        public ActionResult Index()
        {
            var permisos = db.permisos.Include(p => p.Empleado);
            return View(permisos.ToList());
        }

        // GET: Permisos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.permisos.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // GET: Permisos/Create
        public ActionResult Create()
        {
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre");
            return View();
        }

        // POST: Permisos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoFecha,CodigoEmpleado,FechaEntrada,FechaSalida,Comentario")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.permisos.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", permiso.CodigoEmpleado);
            return View(permiso);
        }

        // GET: Permisos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.permisos.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", permiso.CodigoEmpleado);
            return View(permiso);
        }

        // POST: Permisos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoFecha,CodigoEmpleado,FechaEntrada,FechaSalida,Comentario")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoEmpleado = new SelectList(db.empleados, "CodigoEmpleado", "Nombre", permiso.CodigoEmpleado);
            return View(permiso);
        }

        // GET: Permisos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permiso permiso = db.permisos.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // POST: Permisos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Permiso permiso = db.permisos.Find(id);
            db.permisos.Remove(permiso);
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

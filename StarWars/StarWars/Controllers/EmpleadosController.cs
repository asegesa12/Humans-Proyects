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
    public class EmpleadosController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Empleados
        public ActionResult Index(string busqueda)
        {
            var empleados = db.empleados.Include(e => e.Carg).Include(e => e.Depto);

            ViewData["CurrentFilter"] = busqueda;

            var lista = from x in db.empleados
                        select x;

            if (String.IsNullOrEmpty(busqueda))
            {
                return View(db.empleados.ToList());
            }
            else
            {
                lista = lista.Where(x => x.Nombre.Contains(busqueda) || x.codigoDepartamento.Contains(busqueda));
                return View(lista);
            }


        }

        // GET: Empleados/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            ViewBag.codigocargo = new SelectList(db.cargos, "codigocargo", "nombrecargo");
            ViewBag.codigoDepartamento = new SelectList(db.departamentos, "codigodepartamento", "nombredepartamento");
            return View();
        }

        // POST: Empleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoEmpleado,Nombre,Apellido,Telefono,codigoDepartamento,codigocargo,Fecha,Salario,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigocargo = new SelectList(db.cargos, "codigocargo", "nombrecargo", empleado.codigocargo);
            ViewBag.codigoDepartamento = new SelectList(db.departamentos, "codigodepartamento", "nombredepartamento", empleado.codigoDepartamento);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigocargo = new SelectList(db.cargos, "codigocargo", "nombrecargo", empleado.codigocargo);
            ViewBag.codigoDepartamento = new SelectList(db.departamentos, "codigodepartamento", "nombredepartamento", empleado.codigoDepartamento);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoEmpleado,Nombre,Apellido,Telefono,codigoDepartamento,codigocargo,Fecha,Salario,Estatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigocargo = new SelectList(db.cargos, "codigocargo", "nombrecargo", empleado.codigocargo);
            ViewBag.codigoDepartamento = new SelectList(db.departamentos, "codigodepartamento", "nombredepartamento", empleado.codigoDepartamento);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Empleado empleado = db.empleados.Find(id);
            db.empleados.Remove(empleado);
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

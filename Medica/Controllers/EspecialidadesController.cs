using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medica;

namespace Medica.Controllers
{
    public class EspecialidadesController : Controller
    {
        private MedicaContext db = new MedicaContext();

        // GET: Especialidades
        public ActionResult Index()
        {
            return View(db.Especialidades.ToList());
        }

        // GET: Especialidades/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidades = db.Especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }

        // GET: Especialidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EspecialidadId,Nombre,Descripcion")] Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                db.Especialidades.Add(especialidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidades);
        }

        // GET: Especialidades/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidades = db.Especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }

        // POST: Especialidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EspecialidadId,Nombre,Descripcion")] Especialidades especialidades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidades);
        }

        // GET: Especialidades/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidades especialidades = db.Especialidades.Find(id);
            if (especialidades == null)
            {
                return HttpNotFound();
            }
            return View(especialidades);
        }

        // POST: Especialidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Especialidades especialidades = db.Especialidades.Find(id);
            db.Especialidades.Remove(especialidades);
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

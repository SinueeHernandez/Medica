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
    public class MedicoEspecialidadsController : Controller
    {
        private MedicaContext db = new MedicaContext();

        // GET: MedicoEspecialidads
        public ActionResult Index()
        {
            var medicoEspecialidad = db.MedicoEspecialidad.Include(m => m.Especialidades).Include(m => m.Medico);
            return View(medicoEspecialidad.ToList());
        }

        // GET: MedicoEspecialidads/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidad.Find(id);
            if (medicoEspecialidad == null)
            {
                return HttpNotFound();
            }
            return View(medicoEspecialidad);
        }

        // GET: MedicoEspecialidads/Create
        public ActionResult Create()
        {
            ViewBag.EspecilidadId = new SelectList(db.Especialidades, "EspecialidadId", "Nombre");
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre");
            return View();
        }

        // POST: MedicoEspecialidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MedicoId,EspecilidadId")] MedicoEspecialidad medicoEspecialidad)
        {
            if (ModelState.IsValid)
            {
                db.MedicoEspecialidad.Add(medicoEspecialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecilidadId = new SelectList(db.Especialidades, "EspecialidadId", "Nombre", medicoEspecialidad.EspecilidadId);
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre", medicoEspecialidad.MedicoId);
            return View(medicoEspecialidad);
        }

        // GET: MedicoEspecialidads/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidad.Find(id);
            if (medicoEspecialidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecilidadId = new SelectList(db.Especialidades, "EspecialidadId", "Nombre", medicoEspecialidad.EspecilidadId);
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre", medicoEspecialidad.MedicoId);
            return View(medicoEspecialidad);
        }

        // POST: MedicoEspecialidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MedicoId,EspecilidadId")] MedicoEspecialidad medicoEspecialidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicoEspecialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecilidadId = new SelectList(db.Especialidades, "EspecialidadId", "Nombre", medicoEspecialidad.EspecilidadId);
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre", medicoEspecialidad.MedicoId);
            return View(medicoEspecialidad);
        }

        // GET: MedicoEspecialidads/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidad.Find(id);
            if (medicoEspecialidad == null)
            {
                return HttpNotFound();
            }
            return View(medicoEspecialidad);
        }

        // POST: MedicoEspecialidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MedicoEspecialidad medicoEspecialidad = db.MedicoEspecialidad.Find(id);
            db.MedicoEspecialidad.Remove(medicoEspecialidad);
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

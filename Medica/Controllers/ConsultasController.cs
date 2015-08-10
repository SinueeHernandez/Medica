using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medica;
using DayPilot.Web.Mvc.Json;

namespace Medica.Controllers
{
    public class ConsultasController : Controller
    {
        private MedicaContext db = new MedicaContext();

        // GET: Consultas
        public ActionResult Index()
        {
            var consulta = db.Consulta.Include(c => c.Medico).Include(c => c.Paciente);
            return View(consulta.ToList());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre");
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nombres");
            return View();
        }

        // GET: Consultas/Create
        public ActionResult CreateDated(DateTime Fecha, DateTime FechaFin)
        {
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre");
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nombres");
            Consulta consulta = new Consulta();
            consulta.Fecha = Fecha;
            consulta.FechaFin = FechaFin;
            return View(consulta);
        }

        // POST: Consultas/CreateDated
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDated([Bind(Include = "ConsultaId,MedicoId,PacienteId,Fecha,Sintomas,Diagnostico,Tratamiento,Observaciones, FechaFin")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consulta.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre", consulta.MedicoId);
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nombres", consulta.PacienteId);
            //return View(consulta);
            return JavaScript(SimpleJsonSerializer.Serialize("OK"));
        }

        // POST: Consultas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultaId,MedicoId,PacienteId,Fecha,Sintomas,Diagnostico,Tratamiento,Observaciones, FechaFin")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consulta.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre", consulta.MedicoId);
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nombres", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre", consulta.MedicoId);
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nombres", consulta.PacienteId);
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultaId,MedicoId,PacienteId,Fecha,Sintomas,Diagnostico,Tratamiento,Observaciones, FechaFin")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MedicoId = new SelectList(db.Medico, "MedicoID", "Nombre", consulta.MedicoId);
            ViewBag.PacienteId = new SelectList(db.Paciente, "PacienteId", "Nombres", consulta.PacienteId);
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Consulta consulta = db.Consulta.Find(id);
            db.Consulta.Remove(consulta);
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

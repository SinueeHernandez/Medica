using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Medica;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Data.Entity.Infrastructure;
using Medica.Models;

namespace Medica.Controllers
{
    public class MedicosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicos
        public ActionResult Index()
        {
            List<Medico> ListaMedicos = db.Medico.SqlQuery(@"Select * from medicos order by Nombre").ToList();
            return View(/*db.Medico.ToList()*/ListaMedicos);
        }

        // GET: MedicoEspecialidads/Details/3
        // Param: Id del medico
        public ActionResult PorMedico(decimal Medicoid)
        {
            if (Medicoid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Especialidades> medicoEspecialidad = db.Especialidades.SqlQuery(@" select Esp.EspecialidadId, Esp.nombre, Esp.Descripcion from MedicoEspecialidad as mdEsp join Especialidades as Esp on mdEsp.EspecilidadId = Esp.EspecialidadId where mdEsp.medicoid = {0} ;", Medicoid).ToList();
            return PartialView(medicoEspecialidad);
        }

        // GET: Medicos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: Medicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicoID,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,Foto,Biografia")] Medico medico, HttpPostedFileBase upload)
        {
            //medico.Foto = FileUpload(file, medico);
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        medico.Foto = reader.ReadBytes(upload.ContentLength);
                    }
                }
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medico);

        }

        // GET: Medicos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicoID,Nombre,ApellidoPaterno,ApellidoMaterno,Telefono,Foto,Biografia")] Medico medico, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        medico.Foto = reader.ReadBytes(upload.ContentLength);
                    }
                }
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medico);
        }
    
    

        // GET: Medicos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Medico medico = db.Medico.Find(id);
            db.Medico.Remove(medico);
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

        /***********************  Funciones para subir o ver la Foto  ****************************************/
        
        public byte[] FileUpload(HttpPostedFileBase file, Medico medico)
        {
            byte[] array = null;
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

                // save the image path path to the database or you can send image
                // directly to database
                // in-case if you want to store byte[] ie. for DB
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    array = ms.GetBuffer();
                 
                }

            }
            // after successfully uploading redirect the user
            //return RedirectToAction("Create", "Medico");
            return array;
        }

    }
}

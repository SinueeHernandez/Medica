using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medica.Models;

namespace Medica.Controllers
{
    public class FileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: File
        public ActionResult Index(int Id)
        {
            var FileToRetrive = db.Medico.Find(Id);
            return File(FileToRetrive.Foto,"jpg");
        }
    }
}
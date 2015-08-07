using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Medica.Controllers
{
    public class FileController : Controller
    {
        private MedicaContext db = new MedicaContext();
        // GET: File
        public ActionResult Index(int Id)
        {
            var FileToRetrive = db.Medico.Find(Id);
            return File(FileToRetrive.Foto,"jpg");
        }
    }
}
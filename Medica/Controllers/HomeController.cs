using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;

namespace Medica.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }
    }

    class Dpc : DayPilotCalendar
    {
        protected override void OnInit(InitArgs e)
        {
            // UpdateWithMessage("Welcome!", CallBackUpdateType.Full);
            Update(CallBackUpdateType.Full);
        }

        protected override void OnFinish()
        {
            MedicaContext db = new MedicaContext();
            if (UpdateType == CallBackUpdateType.None)
            {
                return;
            }

            DataIdField = "ConsultaId";
            DataStartField = "Fecha";
            DataEndField = "FechaFin";
            DataTextField = "Sintomas";

            Events = from e in db.Consulta select e;
        }

        protected override void OnCommand(CommandArgs e)
        {
            switch (e.Command)
            {
                case "refresh":
                    Update();
                    break;
            }
        }

        protected override void OnEventMove(EventMoveArgs e)
        {
            MedicaContext db = new MedicaContext();
            int ID = int.Parse(e.Id);
            var item = (from ev in db.Consulta where ev.ConsultaId == ID select ev).First();
            if (item != null)
            {
                item.Fecha = e.NewStart;
                item.FechaFin = e.NewEnd;
                db.SaveChanges();
            }

            Update();
        }
    }
}
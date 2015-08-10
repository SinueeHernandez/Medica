﻿using System;
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
        MedicaContext db = new MedicaContext();
        protected override void OnInit(InitArgs e)
        {
       
            UpdateWithMessage("Welcome!", CallBackUpdateType.Full);
            //Update(CallBackUpdateType.Full);
        }

        protected override void OnFinish()
        {
            
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
                case "navigate":
                    StartDate = (DateTime)e.Data["start"];
                    Update(CallBackUpdateType.Full);
                    break;
            }
        }

        protected override void OnEventMove(EventMoveArgs e)
        {
            
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

        protected override void OnEventDelete(EventDeleteArgs e)
        {
            
            int ID = Convert.ToInt32(e.Id);
            var item = (from ev in db.Consulta where ev.ConsultaId == ID select ev).First();
            db.Consulta.Remove(item);
            db.SaveChanges();
            
            Update();
        }
    }
}